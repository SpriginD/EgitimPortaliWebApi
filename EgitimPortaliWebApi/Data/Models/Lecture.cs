namespace EgitimPortaliWebApi.Data.Models
{
    public class Lecture
    {
        public Lecture()
        {
            Students = [];
        }

        public Int16 Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public byte Ects { get; set; }
        public bool IsAdvanced { get; set; }
        public Field Field { get; set; }
        public Int16 FieldId { get; set; }
        public Teacher Teacher { get; set; }
        public Int16 TeacherId { get; set; }
        public List<Student> Students { get; set; }
    }
}
