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
                .OrderByDescending(c => c.NgayDang)
                .ToListAsync();
        }

        public async Task<IEnumerable<CongViec>> GetDsCongViecByCongTyIdAsync(string maCongTy)
        {
            return await _context.CongViecs
                .Include(cv => cv.CongTy)
                .Where(cv => cv.MaCongTy == maCongTy)
                .OrderByDescending(c => c.NgayDang)
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

        public async Task UpdateCongViecAsync(CongViec congViec)
        {
            _context.CongViecs.Update(congViec);
            await _context.SaveChangesAsync();
        }

        public async Task TangLuotXemAsync(string maCongViec)
        {
            var congViec = await _context.CongViecs.FindAsync(maCongViec);
            if (congViec != null)
            {
                congViec.LuotXem = (congViec.LuotXem ?? 0) + 1;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CongViec>> GetDSCongViecbyDSIdAsync(string[] maCongViecs)
        {
            return await _context.CongViecs
                .Where(c => maCongViecs.Contains(c.MaCongViec))
                .Include(c => c.CongTy)
                .ToListAsync();
        }

        public async Task<(List<CongViec> Items, int TotalCount)> LocDsCongViecAsync(
            string keyword, int page, int pageSize)
        {
            var query = _context.CongViecs
                .Include(c => c.CongTy)
                .Where(c => c.TrangThai == "Đang tuyển");

            // Áp dụng bộ lọc từ khóa
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(c => c.TieuDe.ToLower().Contains(keyword) || 
                                        c.MoTa.ToLower().Contains(keyword));
            }

            // // Áp dụng bộ lọc địa điểm
            // if (!string.IsNullOrEmpty(location))
            // {
            //     query = query.Where(c => c.DiaDiem.Contains(location));
            // }

            // // Áp dụng bộ lọc ngành nghề
            // if (!string.IsNullOrEmpty(category))
            // {
            //     query = query.Where(c => c.NganhNghe.Contains(category));
            // }

            // // Áp dụng bộ lọc cấp bậc
            // if (!string.IsNullOrEmpty(level))
            // {
            //     query = query.Where(c => c.CapBac.Contains(level));
            // }

            // // Áp dụng bộ lọc loại hình công việc
            // if (!string.IsNullOrEmpty(jobType))
            // {
            //     query = query.Where(c => c.LoaiHinh.Contains(jobType));
            // }

            var totalItems = await query.CountAsync();
            var items = await query
                .OrderByDescending(c => c.NgayDang)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalItems);
        }


    }
}