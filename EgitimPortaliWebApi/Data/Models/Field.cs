namespace EgitimPortaliWebApi.Data.Models
{
    public class Field
    {
        public Field()
        {
            Lectures = [];
            Students = [];
            Teachers = [];
        }

        public Int16 Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
