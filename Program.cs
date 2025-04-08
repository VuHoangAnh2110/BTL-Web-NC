using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Data;
using BTL_Web_NC.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using BTL_Web_NC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký dịch vụ HttpContextAccessor
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddScoped<ICongTyRepository, CongTyRepository>();
builder.Services.AddScoped<ICongViecRepository, CongViecRepository>();
builder.Services.AddScoped<IHoSoUngVienRepository, HoSoUngVienRepository>();
builder.Services.AddScoped<IUngTuyenRepository, UngTuyenRepository>(); 
builder.Services.AddScoped<IThongBaoRepository, ThongBaoRepository>();
builder.Services.AddScoped<IBannerRepository, BannerRepository>();

// Đăng ký dịch vụ gửi email
builder.Services.AddScoped<IEmailService, EmailService>();

// Thêm dịch vụ Session
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Thêm dịch vụ xác thực
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Trang đăng nhập
        options.AccessDeniedPath = "/Error/ThongBaoTuChoi"; // Khi không đủ quyền
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToAccessDenied = context =>
            {
                if (context.HttpContext.User == null || !context.HttpContext.User.Identity.IsAuthenticated)
                {
                    // Nếu chưa đăng nhập, chuyển hướng đến trang login thay vì AccessDenied
                    context.Response.Redirect(options.LoginPath);
                }
                else
                {
                    context.Response.Redirect(options.AccessDeniedPath);
                }
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

// app.MapControllerRoute(
//     name: "admin",
//     pattern: "Admin/{controller=QLyTaiKhoan}/{action=Index}/{id?}"
// );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
