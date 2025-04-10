using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface ICongViecRepository : IGenericRepository<CongViec>
    {
        Task<IEnumerable<CongViec>> GetDsCongViecAsync();

        Task<IEnumerable<CongViec>> GetDsCongViecByCongTyIdAsync(string idTaiKhoan);
        
        Task AddCongViecAsync(CongViec congViec);
        
        Task<CongViec> GetCongViecByIdAsync(string jobId);
    }
}