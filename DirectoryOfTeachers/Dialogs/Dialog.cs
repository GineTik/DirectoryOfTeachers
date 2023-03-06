using DirectoryOfTeachers.Bot.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs
{
    public abstract class Dialog
    {
        public Action<long> StepsEndedAction;
        public DialogContext DialogContext { get; }

        private List<IDialogStep> Steps => SetSteps();

        private int _currentStepIndex;

        private IDialogStep? PreviosStep => Steps.ElementAtOrDefault(_currentStepIndex - 1);
        private IDialogStep? CurrentStep => Steps.ElementAtOrDefault(_currentStepIndex);
        private IDialogStep? NextStep => Steps.ElementAtOrDefault(_currentStepIndex + 1);
        private bool StepsEnded => CurrentStep == null;

        public Dialog()
        {
            _currentStepIndex = 0;
            DialogContext = new DialogContext();
        }

        public async Task InvokeCurrentStepAsync(DialogParameters parameters)
        {
            if (Steps == null) 
                throw new InvalidOperationException("steps is null");

            if (PreviosStep != null)
                DialogContext.Messages.Add(PreviosStep.ToString(), parameters.Update.Message);
            
            if (StepsEnded == true)
            {
                StepsEndedCallback(parameters);
                StepsEndedAction(parameters.ChatId);
                return;
            }

            await CurrentStep.InvokeAsync(new DialogStepParameters()
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
                DialogContext = DialogContext,
                Next = NextStep,
            });
            _currentStepIndex++;
        }

        public abstract List<IDialogStep> SetSteps();
        public abstract Task StepsEndedCallback(DialogParameters parameters);
    }
}
