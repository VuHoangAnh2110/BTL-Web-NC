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

        public async Task<CongTy?> GetByUserIdAsync(string idTaiKhoan)
        {
            return await _context.CongTys
                .FirstOrDefaultAsync(n => n.TenTaiKhoan == idTaiKhoan);
        }
        public async Task<CongTy?> GetByIdAsync(string maCongTy)
        {
            return await _context.CongTys
                .FirstOrDefaultAsync(c => c.MaCongTy == maCongTy);
        }


        public async Task AddCongTyAsync(CongTy CongTy)
        {
            await _context.CongTys.AddAsync(CongTy);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCongTyAsync(CongTy congTy)
        {
            _context.CongTys.Update(congTy);
            await _context.SaveChangesAsync();
        }

        



    }
}