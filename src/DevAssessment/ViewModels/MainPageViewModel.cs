using AuthModule.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace DevAssessment.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public IEventAggregator EventAggregator { get; }
        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            OnLogOut = new DelegateCommand(ExecuteLogOutCommand);
        }

        public DelegateCommand OnLogOut { get; }

        private void ExecuteLogOutCommand()
        {
            EventAggregator.GetEvent<UserLogoutRequestEvent>().Publish();
        }
    }
}
