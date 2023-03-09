using DirectoryOfTeachers.Framework.Parameters;

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

        public void Init(IServiceProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            DialogContext = new DialogContext();
            _provider = provider;
        }

        public async Task InvokeCurrentStepAsync(DialogParameters parameters)
        {
            if (_previosStepType != null)
                DialogContext.Messages.Add(_previosStepType.Name, parameters.Message);

            if (StepsEnded == true)
            {
                await StepsEndedCallback(parameters);
                StepsEndedAction(parameters.ChatId);
                return;
            }

            var step = _provider.GetService(_nextStepType) as DialogStep;

            if (step == null)
                throw new InvalidOperationException("the step does not inherit the DialogStep");

            step.Init(this);
            _previosStepType = _nextStepType;
            _nextStepType = null;
            await step.InvokeAsync(new DialogStepParameters()
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
                DialogContext = DialogContext,
            });
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
