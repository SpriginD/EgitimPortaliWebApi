using EgitimPortaliWebApi.Data;
using EgitimPortaliWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortaliWebApi.Business.Services
{
    public class LectureService : ILectureService
    {
        private readonly EgitimPortaliContext _context;

        public LectureService(EgitimPortaliContext context)
        {
            _context = context;
        }

        public async Task<Lecture?> GetByIdAsync(int id)
        {
            return await _context.Lectures
                .Include(l => l.Teacher)
                .Include(l => l.Students)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Lecture>> GetListAsync()
        {
            return await _context.Lectures
               .Include(l => l.Teacher)
               .ToListAsync();
        }

        public async Task<Lecture> CreateAsync(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            await _context.SaveChangesAsync();

            return lecture;
        }

        public async Task Delete(Lecture lecture)
        {
            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
        }
    }
}
