using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface IFileUpLoadRepository : IGenericRepository<FileUpload>
    {
        // Thêm mới file vào db
        Task AddFileAsync(FileUpload fileUpload);
        
        // Lấy danh sách tất cả file trong db
        Task<List<FileUpload>> GetAllFilesAsync();

        // Lấy danh sách file của một tài khoản
        Task<List<FileUpload>> GetFilesByUserIdAsync(string tenTaiKhoan);


    }
}