using EgitimPortaliWebApi.Data;
using EgitimPortaliWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortaliWebApi.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly EgitimPortaliContext _context;

        public ArticleService(EgitimPortaliContext context)
        {
            _context = context;
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Article>> GetListAsync()
        {
            return await _context.Articles
               .Include(a => a.Teacher)
               .ToListAsync();
        }

        public async Task<Article> CreateAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return article;
        }

        public async Task Delete(Article article)
        {
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }
    }
}
