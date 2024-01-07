using EgitimPortaliWebApi.Data.Dtos.Field;
using EgitimPortaliWebApi.Data.Models;

namespace EgitimPortaliWebApi.Business.Services
{
    public interface IFieldService
    {
        Task<List<Field>> GetListAsync();
        Task<Field?> GetByIdAsync(int id);
        Task<Field> CreateAsync(CreateFieldDto fieldDto);
        Task DeleteAsync(Field field);
    }
}
