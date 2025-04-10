using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface IFileUpLoadRepository : IGenericRepository<FileUpload>
    {
        
        Task AddFileAsync(FileUpload fileUpload);
        
    }
}