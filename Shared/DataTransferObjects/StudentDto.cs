using System;

namespace Shared.DataTransferObjects;

public record StudentDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public DateOnly? BirthDate { get; set; }
    // TODO: Display courses in which a student is enrolled
}
