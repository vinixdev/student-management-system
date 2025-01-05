using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Course
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(120, ErrorMessage = "Maximum length of Name is 120")]
    public required string Name { get; set; }

    [Required]
    [MaxLength(60, ErrorMessage = "Maximum length of Instructor is 60")]
    public required string Instructor { get; set; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public ICollection<Student>? Students { get; set; }
}