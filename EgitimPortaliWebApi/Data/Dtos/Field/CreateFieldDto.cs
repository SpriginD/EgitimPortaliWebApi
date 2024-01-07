using System.ComponentModel.DataAnnotations;

namespace EgitimPortaliWebApi.Data.Dtos.Field
{
    public record CreateFieldDto
    {
        [Required][StringLength(32)] public string Name { get; set; } = string.Empty;
        [Required] public DateTime StartDate { get; set; }
    }
}
