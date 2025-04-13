using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface ICongViecRepository : IGenericRepository<CongViec>
    {
        Task<IEnumerable<CongViec>> GetDsCongViecAsync();

        Task<IEnumerable<CongViec>> GetDsCongViecByCongTyIdAsync(string maCongTy);
        
        Task AddCongViecAsync(CongViec congViec);
        
        Task<CongViec> GetCongViecByIdAsync(string jobId);

        Task UpdateCongViecAsync(CongViec congViec);

        Task<(List<CongViec> Items, int TotalCount)> LocDsCongViecAsync(
            string keyword, int page, int pageSize);

        
    }
}