namespace EgitimPortaliWebApi.Data.Models
{
    public class Article
    {
        public Int16 Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public Teacher Teacher { get; set; }
        public Int16 TeacherId { get; set; }
    }
}
