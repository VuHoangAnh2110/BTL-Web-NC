using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface INhaTuyenDungRepository : IGenericRepository<NhaTuyenDung>
    {
        Task<NhaTuyenDung?> GetByUserIdAsync(int userId);
        Task AddNhaTuyenDungAsync(NhaTuyenDung nhaTuyenDung);
    }
}