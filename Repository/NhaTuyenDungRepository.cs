using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Repositories;

namespace BTL_Web_NC.Repositories
{
    public class NhaTuyenDungRepository : GenericRepository<NhaTuyenDung>, INhaTuyenDungRepository
    {
        private readonly AppDbContext _context;

        public NhaTuyenDungRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<NhaTuyenDung?> GetByUserIdAsync(int userId)
        {
            return await _context.NhaTuyenDungs
                .FirstOrDefaultAsync(n => n.NguoiDungId == userId);
        }


        public async Task AddNhaTuyenDungAsync(NhaTuyenDung nhaTuyenDung)
        {
            await _context.NhaTuyenDungs.AddAsync(nhaTuyenDung);
            await _context.SaveChangesAsync();
        }
    }
}