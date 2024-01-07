using EgitimPortaliWebApi.Data.Models;

namespace EgitimPortaliWebApi.Business.Services
{
    public interface ILectureService
    {
        Task<List<Lecture>> GetListAsync();
        Task<Lecture?> GetByIdAsync(int id);
        Task<Lecture> CreateAsync(Lecture lecture);
        Task Delete(Lecture lecture);
    }
}
