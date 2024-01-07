using EgitimPortaliWebApi.Data;
using EgitimPortaliWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortaliWebApi.Business.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly EgitimPortaliContext _context;

        public TeacherService(EgitimPortaliContext context)
        {
            _context = context;
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.Field)
                .Include(t => t.Articles)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Teacher>> GetListAsync()
        {
            return await _context.Teachers
               .Include(t => t.Field)
               .Include(t => t.Articles)
               .ToListAsync();
        }

        public async Task<Teacher> CreateAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }

        public async Task Delete(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
