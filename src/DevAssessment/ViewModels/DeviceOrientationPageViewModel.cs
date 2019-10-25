using DevAssessment.Models;
using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace DevAssessment.ViewModels
{
    public class DeviceOrientationPageViewModel : BindableBase
    {
        private IDeviceOrientationService DeviceOrientationService { get; }
        public DeviceOrientationPageViewModel(IDeviceOrientationService deviceOrientationService)
        {
            DeviceOrientationService = deviceOrientationService;

            GetDeviceOrientationCommand = new DelegateCommand(ExecuteGetDeviceOrientationCommand);
        }

        public DeviceOrientation CurrentOrientation
        {
            get => currentOrientation;
            set => SetProperty(ref currentOrientation, value);
        }
        private DeviceOrientation currentOrientation;

        public DelegateCommand GetDeviceOrientationCommand { get; }

        private void ExecuteGetDeviceOrientationCommand()
        {
            CurrentOrientation = DeviceOrientationService.GetOrientation();
        }
    }
}
