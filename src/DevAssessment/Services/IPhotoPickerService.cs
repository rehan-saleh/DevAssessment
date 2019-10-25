using System.IO;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
