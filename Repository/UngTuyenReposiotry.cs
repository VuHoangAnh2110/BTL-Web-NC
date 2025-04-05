using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using BTL_Web_NC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BTL_Web_NC.Repositories
{
    public class UngTuyenRepository : GenericRepository<UngTuyen>, IUngTuyenRepository
    {
        private readonly AppDbContext _context;

        public UngTuyenRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UngTuyen?> GetByUserIdAsync(string userId)
        {
            return await _context.UngTuyens
                .FirstOrDefaultAsync(n => n.TenTaiKhoan == userId);
        }

        public async Task<UngTuyen?> GetByUserIdAndJobIdAsync(string userId, string jobId)
        {
            return await _context.UngTuyens
                .FirstOrDefaultAsync(ut => ut.TenTaiKhoan == userId && ut.MaCongViec == jobId);
        }


        public async Task AddHoSoUngTuyenAsync( UngTuyen ungTuyen)
        {
            await AddAsync(ungTuyen);
            await SaveChangesAsync();
        }
    }
}