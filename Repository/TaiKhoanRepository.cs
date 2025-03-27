using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace BTL_Web_NC.Repositories
{
    public class TaiKhoanRepository : GenericRepository<TaiKhoan>, ITaiKhoanRepository
    {
        private readonly AppDbContext _context;

        public TaiKhoanRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TaiKhoan?> GetByEmailAsync(string? email)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(tk => tk.Email == email);
        }

        public async Task AddTaiKhoanAsync(TaiKhoan TaiKhoan)
        {
            await _context.TaiKhoans.AddAsync(TaiKhoan);
            await _context.SaveChangesAsync();
        }

        public async Task<TaiKhoan?> GetByTenTaiKhoanAsync(string? tenTaiKhoan)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(t => t.TenTaiKhoan == tenTaiKhoan);
        }

        public async Task<TaiKhoan?> GetBySoDienThoaiAsync(string? soDienThoai)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(t => t.SoDienThoai == soDienThoai);
        }

        public async Task<TaiKhoan?> GetByUsernameOrEmailAsync(string? usernameOrEmail)
        {
            return await _context.TaiKhoans
                .FirstOrDefaultAsync(t => 
                    t.Email == usernameOrEmail || t.TenTaiKhoan == usernameOrEmail
                );
        }


    }
}
