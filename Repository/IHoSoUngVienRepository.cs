using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface IHoSoUngVienRepository : IGenericRepository<HoSoUngVien>
    {
        Task<HoSoUngVien?> GetByUserIdAsync(string userId);
        
        Task AddHoSoUngVienAsync(HoSoUngVien ungVien);
                
        
    }
}