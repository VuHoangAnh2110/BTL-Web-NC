using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface IUngTuyenRepository : IGenericRepository<UngTuyen>
    {
        Task<UngTuyen?> GetByUserIdAsync(string userId);

        Task<UngTuyen?> GetByUserIdAndJobIdAsync(string userId, string jobId);

        Task AddHoSoUngTuyenAsync( UngTuyen ungTuyen);
    }
}