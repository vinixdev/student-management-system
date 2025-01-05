using System;

namespace Shared.DataTransferObjects;

public record EnrollmentDto
{
    public Guid Id { get; set; }
    
    public byte? Score { get; set; }

    public DateTime JoinedAt { get; init; } = DateTime.UtcNow;

    public DateTime? EndedAt { get; set; }
    
    public Guid StudentId { get; set; }
    
    public Guid CourseId { get; set; }
}
