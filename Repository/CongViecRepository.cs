using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BTL_Web_NC.Repositories
{
    public class CongViecRepository : GenericRepository<CongViec>, ICongViecRepository
    {
        private readonly AppDbContext _context;

        public CongViecRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CongViec>> GetDsCongViecAsync()
        {
            return await _context.CongViecs
                .Include(cv => cv.CongTy)
                .ToListAsync();
        }

        public async Task<IEnumerable<CongViec>> GetDsCongViecByCongTyIdAsync(string idTaiKhoan)
        {
            return await _context.CongViecs
                .Where(cv => cv.MaCongTy == idTaiKhoan)
                .ToListAsync();
        }

        public async Task AddCongViecAsync(CongViec congViec)
        {
            await _context.CongViecs.AddAsync(congViec);
            await _context.SaveChangesAsync();
        }

        public async Task<CongViec> GetCongViecByIdAsync(string jobId)
        {
            var congViec = await _context.CongViecs
                .Include(cv => cv.CongTy)
                .FirstOrDefaultAsync(cv => cv.MaCongViec == jobId);
            return congViec ?? new CongViec();
        }


    }
}