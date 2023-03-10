using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Factories.Interfaces;

namespace DirectoryOfTeachers.Framework.Factories.Implementations
{
    public class DialogStepFactory : IDialogStepFactory
    {
        private IServiceProvider _provider;

        public DialogStepFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public DialogStep Create(Type stepType, Dialog owner)
        {
            if (stepType == null || stepType.BaseType != typeof(DialogStep)) 
                throw new ArgumentException(nameof(stepType));

            if (owner == null) 
                throw new ArgumentNullException(nameof(owner));

            var step = _provider.GetService(stepType) as DialogStep;
            if (step == null)
                throw new InvalidOperationException("step is not registred in services");

            return step;
        }
    }
}
