using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface ITaiKhoanRepository : IGenericRepository<TaiKhoan>
    {
        Task<TaiKhoan?> GetByEmailAsync(string? email);
        Task AddTaiKhoanAsync(TaiKhoan TaiKhoan);
    }
}
