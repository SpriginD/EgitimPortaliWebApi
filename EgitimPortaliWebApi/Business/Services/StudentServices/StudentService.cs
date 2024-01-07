using EgitimPortaliWebApi.Data;
using EgitimPortaliWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortaliWebApi.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly EgitimPortaliContext _context;

        public StudentService(EgitimPortaliContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Field)
                .Include(s => s.Lectures)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Student>> GetListAsync()
        {
            return await _context.Students
               .Include(s => s.Field)
               .ToListAsync();
        }

        public async Task<Student> CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
