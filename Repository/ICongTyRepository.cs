using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface ICongTyRepository : IGenericRepository<CongTy>
    {
        Task<CongTy?> GetByUserIdAsync(string idTaiKhoan);
        
        Task AddCongTyAsync(CongTy CongTy);
        Task<CongTy?> GetByIdAsync(string id);

        Task UpdateCongTyAsync(CongTy CongTy);
    }
}