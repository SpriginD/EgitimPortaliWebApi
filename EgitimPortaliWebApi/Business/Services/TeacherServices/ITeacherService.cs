using EgitimPortaliWebApi.Data.Models;

namespace EgitimPortaliWebApi.Business.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetListAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> CreateAsync(Teacher teacher);
        Task Delete(Teacher teacher);
    }
}
