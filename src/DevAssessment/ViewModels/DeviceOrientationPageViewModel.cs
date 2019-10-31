using Common.Localization;
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

        public string CurrentOrientation
        {
            get => currentOrientation;
            set => SetProperty(ref currentOrientation, value);
        }
        private string currentOrientation = nameof(DeviceOrientation.Undefined);

        public DelegateCommand GetDeviceOrientationCommand { get; }

        private void ExecuteGetDeviceOrientationCommand()
        {
            DeviceOrientation orientation = DeviceOrientationService.GetOrientation();

            switch (orientation)
            {
                case DeviceOrientation.Undefined:
                    CurrentOrientation = AppResources.UndefinedOrientationLabel;
                    break;
                case DeviceOrientation.Landscape:
                    CurrentOrientation = AppResources.LandscapeOrientationLabel;
                    break;
                case DeviceOrientation.Portrait:
                    CurrentOrientation = AppResources.PortraitOrientationLabel;
                    break;
                default:
                    CurrentOrientation = AppResources.UndefinedOrientationLabel;
                    break;
            }
        }
    }
}
