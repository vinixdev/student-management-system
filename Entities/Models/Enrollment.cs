using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Enrollment
{
    [Required]
    public Guid Id { get; set; }

    [Range(0, 100, ErrorMessage = "Score must be between 0 to 100")]
    public byte Score { get; set; }

    public DateTime JoinedAt { get; init; } = DateTime.Now;

    public DateTime? EndedAt { get; set; }

    [Required]
    public Guid StudentId { get; set; }

    [Required]
    public Guid CourseId { get; set; }
}