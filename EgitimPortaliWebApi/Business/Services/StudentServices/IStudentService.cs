using EgitimPortaliWebApi.Data.Models;

namespace EgitimPortaliWebApi.Business.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetListAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task Delete(Student student);
    }
}
