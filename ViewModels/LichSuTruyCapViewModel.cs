using BTL_Web_NC.Models;

namespace BTL_Web_NC.ViewModels
{
    public class LichSuTruyCapViewModel
    {
        // Thông tin truy cập từ session và cookie
        public TruyCapInfo SessionAccess { get; set; }
        public TruyCapInfo CookieAccess { get; set; }
        
        // Thông tin chi tiết công việc truy cập gần nhất
        public CongViec CongViecSession { get; set; }
        public CongViec CongViecCookie { get; set; }
        
        // Danh sách các công việc đã xem
        public List<CongViec> DanhSachDaXemSession { get; set; } = new List<CongViec>();
        public List<CongViec> DanhSachDaXemCookie { get; set; } = new List<CongViec>();
    
        public Dictionary<string, string> AllCookies { get; set; } = new Dictionary<string, string>();

    
    }
}