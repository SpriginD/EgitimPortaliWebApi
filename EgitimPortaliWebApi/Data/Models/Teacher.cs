namespace EgitimPortaliWebApi.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Lectures = [];
            Articles = [];
        }

        public Int16 Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string graduateUniversity { get; set; } = string.Empty;
        public byte Age { get; set; }
        public byte ExperienceYear { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Field Field { get; set; }
        public Int16 FieldId { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<Article> Articles { get; set; }

    }
}
