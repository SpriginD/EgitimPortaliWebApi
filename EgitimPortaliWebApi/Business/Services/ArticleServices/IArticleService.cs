using EgitimPortaliWebApi.Data.Models;

namespace EgitimPortaliWebApi.Business.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetListAsync();
        Task<Article?> GetByIdAsync(int id);
        Task<Article> CreateAsync(Article article);
        Task Delete(Article article);
    }
}
