using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Parameters;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public abstract class Dialog
    {
        public Action<long> StepsEndedAction;
        public DialogContext DialogContext { get; private set; }
        
        public bool StepsEnded => _nextStepType == null;

        private Type? _nextStepType;
        private Type? _previosStepType;
        private IServiceProvider _provider;
        private IDialogStepFactory _stepFactory;

        public void Init(IServiceProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            DialogContext = new DialogContext();
            _provider = provider;
            _stepFactory = _provider.GetRequiredService<IDialogStepFactory>();
        }

        public async Task InvokeCurrentStepAsync(DialogParameters parameters)
        {
            var stepParameters = new DialogStepParameters()
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
                DialogContext = DialogContext,
            };

            if (_previosStepType != null)
            {
                DialogContext.Messages.Add(_previosStepType.Name, parameters.Message);
                var previosStep = _stepFactory.Create(_previosStepType, this);
                await previosStep.TakeResultAsync(stepParameters);
            }

            if (StepsEnded == true)
            {
                await StepsEndedCallback(parameters);
                StepsEndedAction(parameters.ChatId);
                return;
            }

            var step = _stepFactory.Create(_nextStepType, this);

            _previosStepType = _nextStepType;
            _nextStepType = null;

            await step.InvokeAsync(stepParameters);
        }

        public void SetNextStep(Type type)
        {
            if (type.BaseType != typeof(DialogStep))
                throw new ArgumentException(nameof(type));

            _nextStepType = type;
        }

        public abstract Task StepsEndedCallback(DialogParameters parameters);
    }
}
