using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class DialogBase : BindableBase, IDialogAware
    {
        public DialogBase()
        {
            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }
        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        public virtual bool CanCloseDialog() => true;

        public virtual void OnDialogClosed() { }

        public virtual void OnDialogOpened(IDialogParameters parameters) { }
    }
}
