using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTL_Web_NC.Repositories
{
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        private readonly AppDbContext _context;

        public BannerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Banner>> GetAllBannersAsync()
        {
            // Sử dụng Entity Framework để truy vấn dữ liệu
            return await _context.Banners
                .OrderBy(b => b.NgayTao)
                .ToListAsync();
        }
    }
}