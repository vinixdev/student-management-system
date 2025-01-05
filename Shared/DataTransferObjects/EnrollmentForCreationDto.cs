using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record EnrollmentForCreationDto
{
    [Range(0, 100, ErrorMessage = "Score must be between 0 to 100")]
    public byte? Score { get; set; }

    public DateTime JoinedAt { get; init; } = DateTime.UtcNow;

    public DateTime? EndedAt { get; set; }

    [Required(ErrorMessage = "StudentId is required.")]
    public Guid StudentId { get; set; }

    [Required(ErrorMessage = "CourseId is required.")]
    public Guid CourseId { get; set; }
}