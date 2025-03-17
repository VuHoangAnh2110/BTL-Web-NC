using BTL_Web_NC.Models;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface INguoiDungRepository : IGenericRepository<NguoiDung>
    {
        Task<NguoiDung?> GetByEmailAsync(string? email);
        Task AddNguoiDungAsync(NguoiDung nguoiDung);
    }
}
