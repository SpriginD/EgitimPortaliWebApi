using EgitimPortaliWebApi.Data;
using EgitimPortaliWebApi.Data.Dtos.Field;
using EgitimPortaliWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortaliWebApi.Business.Services
{
    public class FieldService : IFieldService
    {
        private readonly EgitimPortaliContext _context;

        public FieldService(EgitimPortaliContext context)
        {
            _context = context;
        }

        public async Task<Field?> GetByIdAsync(int id)
        {
            return await _context.Fields
                .Include(f => f.Lectures)
                .Include(f => f.Teachers)
                .Include(f => f.Students)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Field>> GetListAsync()
        {
            return await _context.Fields
                .Include(f => f.Lectures)
                .Include(f => f.Teachers)
                .Include(f => f.Students)
                .ToListAsync();
        }

        public async Task<Field> CreateAsync(CreateFieldDto fieldDto)
        {
            Field field = new() 
            { 
                Name = fieldDto.Name,
                StartDate = DateOnly.FromDateTime(fieldDto.StartDate),
            };

            _context.Fields.Add(field);
            await _context.SaveChangesAsync();

            return field;
        }

        public async Task DeleteAsync(Field field)
        {
            _context.Fields.Remove(field);
            await _context.SaveChangesAsync();
        }
    }
}
