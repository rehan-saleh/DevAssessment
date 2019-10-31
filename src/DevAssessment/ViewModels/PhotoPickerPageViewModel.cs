using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace DevAssessment.ViewModels
{
    public class PhotoPickerPageViewModel : BindableBase
    {
        private IPhotoPickerService PhotoPickerService { get; }

        public PhotoPickerPageViewModel(IPhotoPickerService photoPickerService)
        {
            PhotoPickerService = photoPickerService;

            PickPhotoCommand = new DelegateCommand(ExecutePickPhotoCommand);
        }

        public ImageSource Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private ImageSource image;

        public DelegateCommand PickPhotoCommand { get; set; }

        private async void ExecutePickPhotoCommand()
        {
            Stream photo = await PhotoPickerService.GetImageStreamAsync();
            if (photo != null)
            {
                Image = ImageSource.FromStream(() => photo);
            }
        }
    }
}
