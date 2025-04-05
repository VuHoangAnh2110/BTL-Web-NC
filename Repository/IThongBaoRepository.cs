using System.Collections.Generic;
using System.Threading.Tasks;
using BTL_Web_NC.Models;

namespace BTL_Web_NC.Repositories
{
    public interface IThongBaoRepository : IGenericRepository<ThongBao>
    {
        Task<IEnumerable<ThongBao>> GetAllThongBaoByIdCongTy(string IdCongTy); //Lấy tất cả thông báo

        Task AddThongBaoAsync(ThongBao thongBao);

        Task UpdateThongBaoAsync(ThongBao thongBao);

        Task<int> GetUnreadNotificationCount(string idCongTy);

        Task<ThongBao> GetThongBaoByIdAsync(string id);
    }
}
