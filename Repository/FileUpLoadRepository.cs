using BTL_Web_NC.Data;
using BTL_Web_NC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BTL_Web_NC.Repositories
{
    public class FileUpLoadRepository : GenericRepository<FileUpload>, IFileUpLoadRepository
    {
        private readonly AppDbContext _context;

        public FileUpLoadRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddFileAsync(FileUpload fileUpload)
        {
            await _context.Files.AddAsync(fileUpload);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FileUpload>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<List<FileUpload>> GetFilesByUserIdAsync(string tenTaiKhoan)
        {
            return await _context.Files
                .Where(f => f.TenTaiKhoan == tenTaiKhoan).ToListAsync();
        }




    }
}