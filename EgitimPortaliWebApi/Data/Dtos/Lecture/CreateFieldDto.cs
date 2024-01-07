using System.ComponentModel.DataAnnotations;

namespace EgitimPortaliWebApi.Data.Dtos.Lecture
{
    public record LectureFieldDto
    {
        [Required][StringLength(32)] public string Name { get; set; } = String.Empty;
        [Required][StringLength(32)] public string ClassName { get; set; } = String.Empty;
        [Required] public byte Ects { get; set; }
        [Required] public bool IsAdvanced { get; set; }
        [Required] public Int16 TeacherId { get; set; }
        [Required] public Int16 FieldId { get; set; }
    }
}
