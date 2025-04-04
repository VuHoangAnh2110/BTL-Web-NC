using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Models;

namespace BTL_Web_NC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CongTy> CongTys { get; set; }
        public DbSet<CongViec> CongViecs { get; set; }
        public DbSet<FileUpload> Files { get; set; }
        public DbSet<HoSoUngVien> HoSoUngViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<UngTuyen> UngTuyens { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Khóa chính
            modelBuilder.Entity<CongTy>().HasKey(ct => ct.MaCongTy);
            modelBuilder.Entity<CongViec>().HasKey(cv => cv.MaCongViec);
            modelBuilder.Entity<FileUpload>().HasKey(f => f.MaFile);
            modelBuilder.Entity<HoSoUngVien>().HasKey(hs => hs.MaHoSo);
            modelBuilder.Entity<TaiKhoan>().HasKey(tk => tk.TenTaiKhoan);
            modelBuilder.Entity<ThongBao>().HasKey(tb => tb.MaThongBao);
            modelBuilder.Entity<UngTuyen>().HasKey(ut => ut.MaUngTuyen);

            // Quan hệ giữa các bảng - Cập nhật tên navigation properties theo tiếng Việt
            modelBuilder.Entity<CongTy>()
                .HasOne(ct => ct.TaiKhoan)
                .WithMany(tk => tk.DanhSachCongTy)
                .HasForeignKey(ct => ct.TenTaiKhoan);

            modelBuilder.Entity<CongViec>()
                .HasOne(cv => cv.CongTy)
                .WithMany(ct => ct.DanhSachCongViec)
                .HasForeignKey(cv => cv.MaCongTy);

            modelBuilder.Entity<HoSoUngVien>()
                .HasOne(hs => hs.TaiKhoan)
                .WithMany(tk => tk.DanhSachHoSo)
                .HasForeignKey(hs => hs.TenTaiKhoan);

            modelBuilder.Entity<FileUpload>()
                .HasOne(f => f.TaiKhoan)
                .WithMany(tk => tk.DanhSachFile)
                .HasForeignKey(f => f.TenTaiKhoan);
                
            // Thêm mối quan hệ cho ThongBao
            modelBuilder.Entity<ThongBao>()
                .HasOne(tb => tb.TaiKhoan)
                .WithMany(tk => tk.DanhSachThongBao)
                .HasForeignKey(tb => tb.TenTaiKhoan);
                
            modelBuilder.Entity<ThongBao>()
                .HasOne(tb => tb.CongTy)
                .WithMany()
                .HasForeignKey(tb => tb.MaCongTy)
                .OnDelete(DeleteBehavior.NoAction);
                
            modelBuilder.Entity<ThongBao>()
                .HasOne(tb => tb.CongViec)
                .WithMany()
                .HasForeignKey(tb => tb.MaCongViec)
                .OnDelete(DeleteBehavior.NoAction);
                
            // Thêm mối quan hệ cho UngTuyen
            modelBuilder.Entity<UngTuyen>()
                .HasOne(ut => ut.TaiKhoan)
                .WithMany(tk => tk.DanhSachUngTuyen)
                .HasForeignKey(ut => ut.TenTaiKhoan)
                .OnDelete(DeleteBehavior.NoAction);
                
            modelBuilder.Entity<UngTuyen>()
                .HasOne(ut => ut.CongViec)
                .WithMany(cv => cv.DanhSachUngTuyen)
                .HasForeignKey(ut => ut.MaCongViec);
        }
    }
}