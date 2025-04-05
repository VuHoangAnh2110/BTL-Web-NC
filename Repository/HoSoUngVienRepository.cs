using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BTL_Web_NC.Repositories
{
    public class HoSoUngVienRepository : GenericRepository<HoSoUngVien>, IHoSoUngVienRepository
    {
        private readonly AppDbContext _context;

        public HoSoUngVienRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<HoSoUngVien?> GetByUserIdAsync(string userId)
        {
            return await _context.HoSoUngViens
                .FirstOrDefaultAsync(n => n.TenTaiKhoan == userId);
        }

        public async Task AddHoSoUngVienAsync(HoSoUngVien ungVien)
        {
            await AddAsync(ungVien);
            await SaveChangesAsync();
        }



    }
}