
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
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Khóa chính
            modelBuilder.Entity<CongTy>().HasKey(ct => ct.MaCongTy);
            modelBuilder.Entity<CongViec>().HasKey(cv => cv.MaCongViec);
            modelBuilder.Entity<FileUpload>().HasKey(f => f.MaFile);
            modelBuilder.Entity<HoSoUngVien>().HasKey(hs => hs.MaHoSo);
            modelBuilder.Entity<TaiKhoan>().HasKey(tk => tk.TenTaiKhoan);
            modelBuilder.Entity<ThongBao>().HasKey(tb => tb.MaThongBao);

            // Quan hệ giữa các bảng
            modelBuilder.Entity<CongTy>()
                .HasOne(ct => ct.TaiKhoan)
                .WithMany(tk => tk.CongTys)
                .HasForeignKey(ct => ct.TenTaiKhoan);

            modelBuilder.Entity<CongViec>()
                .HasOne(cv => cv.CongTy)
                .WithMany(ct => ct.CongViecs)
                .HasForeignKey(cv => cv.MaCongTy);

            modelBuilder.Entity<HoSoUngVien>()
                .HasOne(hs => hs.TaiKhoan)
                .WithMany(tk => tk.HoSoUngViens)
                .HasForeignKey(hs => hs.TenTaiKhoan);

            modelBuilder.Entity<FileUpload>()
                .HasOne(f => f.TaiKhoan)
                .WithMany(tk => tk.Files)
                .HasForeignKey(f => f.TenTaiKhoan);
        }
    }

}
