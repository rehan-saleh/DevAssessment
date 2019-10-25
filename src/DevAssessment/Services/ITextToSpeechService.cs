using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface ITextToSpeechService
    {
        Task SpeakAsync(string text);
    }
}
