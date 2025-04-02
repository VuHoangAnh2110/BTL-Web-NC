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

        // Lấy tài khoản theo email
        public async Task<TaiKhoan?> GetByEmailAsync(string? email)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(tk => tk.Email == email);
        }

        //  Thêm mới tài khoản 
        public async Task AddTaiKhoanAsync(TaiKhoan TaiKhoan)
        {
            await _context.TaiKhoans.AddAsync(TaiKhoan);
            await _context.SaveChangesAsync();
        }

        // Lấy tài khoản tên tài khoản
        public async Task<TaiKhoan?> GetByTenTaiKhoanAsync(string? tenTaiKhoan)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(t => t.TenTaiKhoan == tenTaiKhoan);
        }

        // Lấy tài khoản theo số điện thoại
        public async Task<TaiKhoan?> GetBySoDienThoaiAsync(string? soDienThoai)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(t => t.SoDienThoai == soDienThoai);
        }

        // Lấy tài khoản theo email hoặc tên tài khoản
        public async Task<TaiKhoan?> GetByUsernameOrEmailAsync(string? usernameOrEmail)
        {
            return await _context.TaiKhoans
                .FirstOrDefaultAsync(t => 
                    t.Email == usernameOrEmail || t.TenTaiKhoan == usernameOrEmail
                );
        }

        // Lấy danh sach tất cả tài khoản
        public async Task<IEnumerable<TaiKhoan>> GetAllAsync()
        {
            return await _context.TaiKhoans.ToListAsync();
        }

        // Cập nhật tài khoản
        public async Task UpdateAsync(TaiKhoan TaiKhoan)
        {
            _context.TaiKhoans.Update(TaiKhoan);
            await _context.SaveChangesAsync();
        }


    }
}
