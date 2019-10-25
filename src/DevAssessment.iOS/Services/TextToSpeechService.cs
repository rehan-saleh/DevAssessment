using AVFoundation;
using DevAssessment.Services;
using System;
using System.Threading.Tasks;

namespace DevAssessment.iOS.Services
{
    public class TextToSpeechService : ITextToSpeechService, IDisposable
    {
        AVSpeechSynthesizer synthesizer;
        AVSpeechUtterance utterance;
        TaskCompletionSource<bool> tcsUtterance;

        public TextToSpeechService()
        {
            synthesizer = new AVSpeechSynthesizer();
        }

        public async Task SpeakAsync(string text)
        {
            tcsUtterance = new TaskCompletionSource<bool>();

            synthesizer.DidFinishSpeechUtterance += OnFinishedSpeechUtterance;
            utterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 3,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 1.0f,
                PitchMultiplier = 1.0f,
            };
            synthesizer.SpeakUtterance(utterance);
            await tcsUtterance.Task;
        }

        void OnFinishedSpeechUtterance(object sender, AVSpeechSynthesizerUteranceEventArgs e)
        {
            tcsUtterance?.TrySetResult(true);
        }

        public void Dispose()
        {
            synthesizer.DidFinishSpeechUtterance -= OnFinishedSpeechUtterance;
            utterance.Dispose();
            synthesizer.Dispose();
            utterance = null;
            synthesizer = null;
        }
    }
}