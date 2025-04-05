using System;
using System.Text;

namespace BTL_Web_NC.Helpers
{
    public static class IdGenerator
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Tạo ID theo định dạng "ddMMyy" + 2 chữ cái thường + 2 số
        /// Ví dụ: Ngày 12/10/2024 sẽ tạo ID dạng "121024ab68" (với ab68 là ngẫu nhiên)
        /// </summary>
        public static string GenerateRandomId(string prefix = "")
        {
            // Lấy ngày hiện tại và định dạng thành ddMMyy
            DateTime now = DateTime.Now;
            string dateFormat = now.ToString("ddMMyy");
            
            // Tạo 2 chữ cái thường ngẫu nhiên (a-z)
            char letter1 = (char)('a' + _random.Next(0, 26));
            char letter2 = (char)('a' + _random.Next(0, 26));
            
            // Tạo 2 số ngẫu nhiên (0-9)
            int digit1 = _random.Next(0, 10);
            int digit2 = _random.Next(0, 10);
            
            // Kết hợp thành chuỗi ID
            string id = $"{dateFormat}{letter1}{letter2}{digit1}{digit2}";
            
            // Nếu có tiền tố, thêm vào trước ID
            return string.IsNullOrEmpty(prefix) ? id : $"{prefix}{id}";
        }
        
        // Hàm sinh ID cho các loại đối tượng cụ thể
        public static string GenerateCongTyId() => GenerateRandomId("CT");
        
        public static string GenerateCongViecId() => GenerateRandomId("CV");
        
        public static string GenerateFileId() => GenerateRandomId("FL");
        
        public static string GenerateHoSoId() => GenerateRandomId("HS");
        
        public static string GenerateThongBaoId() => GenerateRandomId("TB");
        
        public static string GenerateUngTuyenId() => GenerateRandomId("UT");
    }
}