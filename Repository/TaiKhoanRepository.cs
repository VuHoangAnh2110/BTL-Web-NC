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

        // Tìm kiếm và lọc danh sách tài khoản
        public async Task<IEnumerable<TaiKhoan>> BoLocTimKiemTKAsync(string search, string vaiTro, string trangThai)
        {
            // Lấy tất cả tài khoản
            var query = _context.TaiKhoans.AsQueryable();
            
            // Lọc theo tên tài khoản hoặc họ tên hoặc email
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                query = query.Where(a => a.TenTaiKhoan.ToLower().Contains(search) 
                                        || (a.HoTen != null && a.HoTen.ToLower().Contains(search)) 
                                        || (a.Email != null && a.Email.ToLower().Contains(search))
                                    );
            }
            
            // Lọc theo vai trò
            if (!string.IsNullOrEmpty(vaiTro) && vaiTro != "all")
            {
                query = query.Where(a => a.VaiTro == vaiTro);
            }
            
            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "all")
            {
                int trangThaiValue = int.Parse(trangThai);
                query = query.Where(a => a.TrangThai == trangThaiValue);
            }
            
            // Sắp xếp theo ngày tạo mới nhất
            return await query.OrderByDescending(a => a.NgayTao).ToListAsync();
        }



    }
}
