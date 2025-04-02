using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface ITaiKhoanRepository : IGenericRepository<TaiKhoan>
    {
        // Lấy tài khoản theo email
        Task<TaiKhoan?> GetByEmailAsync(string? email);
        // Thêm mới tài khoản
        Task AddTaiKhoanAsync(TaiKhoan TaiKhoan);
        // Lấy tài khoản theo tên tài khoản
        Task<TaiKhoan?> GetByTenTaiKhoanAsync(string? tenTaiKhoan);
        // Lấy tài khoản theo số điện thoại
        Task<TaiKhoan?> GetBySoDienThoaiAsync(string? soDienThoai);
        // Lấy tài khoản theo tên tài khoản hoặc email
        Task<TaiKhoan?> GetByUsernameOrEmailAsync(string? usernameOrEmail);
        // Lấy danh sách tài khoản
        Task<IEnumerable<TaiKhoan>> GetAllAsync();
        // Cập nhật tài khoản
        Task UpdateAsync(TaiKhoan TaiKhoan);
        // Xóa tài khoản
        // Task DeleteTaiKhoanAsync(string? id);
    }
}
