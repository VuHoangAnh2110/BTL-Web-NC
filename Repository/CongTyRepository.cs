using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Repositories;

namespace BTL_Web_NC.Repositories
{
    public class CongTyRepository : GenericRepository<CongTy>, ICongTyRepository
    {
        private readonly AppDbContext _context;

        public CongTyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Lấy thông tin công ty theo id tài khoản
        public async Task<CongTy?> GetByUserIdAsync(string idTaiKhoan)
        {
            return await _context.CongTys
                .FirstOrDefaultAsync(n => n.TenTaiKhoan == idTaiKhoan);
        }

        // Lấy thông tin công ty theo mã công ty
        public async Task<CongTy?> LayCongTyTheoMaCTAsync(string idCongTy)
        {
            return await _context.CongTys
                .FirstOrDefaultAsync(n => n.MaCongTy == idCongTy);
        }

        public async Task AddCongTyAsync(CongTy CongTy)
        {
            await _context.CongTys.AddAsync(CongTy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCongTyAsync(CongTy CongTy)
        {
            Update(CongTy);
            await SaveChangesAsync();
        }

        public async Task<List<CongTy>> GetCongTyMoiNhatAsync(int soLuong)
        {
            return await _context.CongTys
                .OrderByDescending(c => c.NgayTao)
                .Take(soLuong)
                .ToListAsync();
        }

        public async Task<(List<CongTy> Items, int TotalCount)> LocDsCongTyAsync(
            string keyword, int page, int pageSize)
        {
            var query = _context.CongTys
                .Include(c => c.TaiKhoan);

            // Áp dụng bộ lọc từ khóa
            // if (!string.IsNullOrEmpty(keyword))
            // {
            //     keyword = keyword.ToLower();
            //     query = query.Where(c => c.TenCongTy.ToLower().Contains(keyword) ||
            //                             c.DiaChi.ToLower().Contains(keyword));
            // }

            // // Áp dụng bộ lọc ngành nghề
            // if (!string.IsNullOrEmpty(industry))
            // {
            //     query = query.Where(c => c.LinhVuc.Contains(industry));
            // }

            var totalItems = await query.CountAsync();
            var items = await query
                .OrderByDescending(c => c.NgayTao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalItems);
        }




    }
}