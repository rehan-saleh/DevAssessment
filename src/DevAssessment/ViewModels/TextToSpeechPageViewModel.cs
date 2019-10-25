using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace DevAssessment.ViewModels
{
    public class TextToSpeechPageViewModel : BindableBase
    {
        private ITextToSpeechService TextToSpeechService { get; }

        public TextToSpeechPageViewModel(ITextToSpeechService textToSpeechService)
        {
            TextToSpeechService = textToSpeechService;

            SpeakCommand = new DelegateCommand(ExecuteSpeakCommand);
        }

        public string TextToSpeak { get; set; }

        public DelegateCommand SpeakCommand { get; }

        private void ExecuteSpeakCommand()
        {
            TextToSpeechService.SpeakAsync(TextToSpeak);
        }
    }
}
