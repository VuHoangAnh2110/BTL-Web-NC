
using Microsoft.EntityFrameworkCore;
using BTL_Web_NC.Models;

namespace BTL_Web_NC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
    }

    
}
