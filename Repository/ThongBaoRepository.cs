using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Data;
using BTL_Web_NC.Models;

namespace BTL_Web_NC.Repositories
{
    public class ThongBaoRepository : GenericRepository<ThongBao>, IThongBaoRepository
    {
        private readonly AppDbContext _context;

        public ThongBaoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //Thêm thông báo
        public async Task AddThongBaoAsync(ThongBao thongBao)
        {
            await AddAsync(thongBao);
            await SaveChangesAsync();
        }

        //Lấy tất cả thông báo
        public async Task<IEnumerable<ThongBao>> GetAllThongBaoByIdCongTy(string IdCongTy)
        {
            return await _context.ThongBaos
                .Where(tb => tb.MaCongTy == IdCongTy)
                .OrderByDescending(tb => tb.NgayThongBao)
                .ToListAsync();
        }

        public async Task UpdateThongBaoAsync(ThongBao thongBao)
        {
            Update(thongBao);
            await SaveChangesAsync();
        }

        //Lấy số lượng thông báo chưa đọc
        public async Task<int> GetUnreadNotificationCount(string idCongTy)
        {
            return await _context.ThongBaos
                .Where(tb => tb.MaCongTy == idCongTy && tb.DaXem == false)
                .CountAsync();
        }

        //Lấy thông báo theo id
        public async Task<ThongBao?> GetThongBaoByIdAsync(string id)
        {
            return await _context.ThongBaos
                .FirstOrDefaultAsync(tb => tb.MaThongBao == id);
        }


    }
}
