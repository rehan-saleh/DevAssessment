using DevAssessment.Services;
using DevAssessment.UWP.Services;
using Prism;
using Prism.Ioc;

namespace DevAssessment.UWP
{
    public sealed partial class MainPage : IPlatformInitializer
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new DevAssessment.App(this));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDeviceOrientationService, DeviceOrientationService>();
            containerRegistry.Register<ITextToSpeechService, TextToSpeechService>();
            containerRegistry.Register<IPhotoPickerService, PhotoPickerService>();
        }
    }
}
