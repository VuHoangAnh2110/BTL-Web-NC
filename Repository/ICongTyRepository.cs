using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface ICongTyRepository : IGenericRepository<CongTy>
    {
        Task<CongTy?> GetByUserIdAsync(string idTaiKhoan);
        
        Task<CongTy?> LayCongTyTheoMaCTAsync(string idCongTy);
        
        Task AddCongTyAsync(CongTy CongTy);

        Task UpdateCongTyAsync(CongTy CongTy);

        Task<List<CongTy>> GetCongTyMoiNhatAsync(int soLuong);


        
    }
}