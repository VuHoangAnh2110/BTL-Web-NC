using BTL_Web_NC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public interface IBannerRepository : IGenericRepository<Banner>
    {
        Task<List<Banner>> GetAllBannersAsync();
    }
}