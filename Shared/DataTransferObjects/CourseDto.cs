using System;

namespace Shared.DataTransferObjects;

public record CourseDto
{

    public Guid Id { get; set; }

    public required string Name { get; set; }
    
    public required string Instructor { get; set; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}
