using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface IUngTuyenRepository : IGenericRepository<UngTuyen>
    {
        Task<UngTuyen?> GetByUserIdAsync(string userId);

        Task<UngTuyen?> GetByUserIdAndJobIdAsync(string userId, string jobId);

        Task AddHoSoUngTuyenAsync( UngTuyen ungTuyen);

        Task<List<UngTuyen>> GetDSUngTuyenByCongViecAsync(string jobId);

        Task<UngTuyen?> GetUngTuyenByIdAsync(string ungTuyenId);

        Task UpdateUngTuyenAsync(UngTuyen ungTuyen);

        Task<List<UngTuyen>> GetDSUngTuyenByUserIdAsync(string userId);


        
    }
}