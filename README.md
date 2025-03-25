# Sàn Giao Dịch Việc Làm Trực Tuyến

## Giới Thiệu
Dự án này là một sàn giao dịch việc làm trực tuyến, giúp kết nối nhà tuyển dụng và người tìm việc. Ứng dụng cung cấp nhiều tính năng hỗ trợ việc tìm kiếm, đăng tuyển và quản lý tuyển dụng hiệu quả.

## Tính Năng
- 💼 **Dành cho nhà tuyển dụng:**
  - Đăng tin tuyển dụng
  - Quản lý danh sách ứng viên
  - Liên hệ với người tìm việc
  
- 🤝 **Dành cho người tìm việc:**
  - Tìm kiếm việc làm theo ngành nghề, địa điểm, mức lương
  - Đăng ký tài khoản, tạo CV trực tuyến
  - Nộp đơn xin việc và nhận thông báo tuyển dụng

- 🌐 **Tính năng khác:**
  - . . . 

## Công Nghệ Sử Dụng
- **Back-end:** ASP.NET Core MVC 8
- **Front-end:** HTML, CSS, JavaScript (Bootstrap 5)
- **Cơ sở dữ liệu:** MySQL, PostgreSQL
- **Authentication:** OAuth 2.0, JWT
- **Hỗ trợ gửi mail:** PHPMailer
- **Triển khai:** Docker, Nginx

## Cài Đặt
### Yêu cầu hệ thống
- .NET 8 SDK
- Node.js 18+
- MySQL hoặc PostgreSQL
- Docker (tùy chọn)

### Hướng dẫn cài đặt
1. Clone repository:
   ```sh
   git clone https://github.com/VuHoangAnh2110/BTL-Web-NC.git
   cd BTL-Web-NC
   ```
2. Cài đặt dependencies:
    - Đối với .NET
   ```sh
   dotnet restore
   ```
    - Đối với Node.js
   ```sh
   npm install
   ```
4. Cấu hình môi trường:
   - Sao chép file `appsettings.example.json` thành `appsettings.json` và chỉnh sửa thông tin kết nối database.
   - Đã có `appsettings.json` thì vào chỉnh sửa thông tin kết nối database.
   - Mở terminal chạy lệnh bên dưới để không theo dõi thay đổi của file appsettings.json.
   ```sh
   git update-index --assume-unchanged appsettings.json
   ```
5. Chạy ứng dụng:
    - Đối với .NET
   ```sh
   dotnet run
   ```
    - Đối với Node.js
   ```sh
   npm start
   ```
7. Truy cập ứng dụng tại: `http://localhost:5000`

## Đóng Góp
Chúng tôi hoan nghênh mọi đóng góp! Hãy fork repo, tạo branch mới, commit thay đổi và gửi pull request.

## Giấy Phép
Dự án này được phát hành dưới giấy phép MIT.

## Liên Hệ
- **Email:** G27@gmail.com
- **Website:** https://G27.com

