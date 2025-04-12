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
        public async Task DeleteCongTyAsync(CongTy CongTy)
        {
            Delete(CongTy);
            await SaveChangesAsync();
        }

        public async Task<List<CongTy>> GetCongTyMoiNhatAsync(int soLuong)
        {
            return await _context.CongTys
                .OrderByDescending(c => c.NgayTao)
                .Take(soLuong)
                .ToListAsync();
        }

        public async Task<CongTy> GetByIdAsync(string id)
        {
            return await _context.CongTys.FindAsync(id);
        }
    }
}