using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Student
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(60, ErrorMessage = "Maximum length of FirstName is 60")]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(60, ErrorMessage = "Maximum length of LastName is 60")]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string StdId { get; set; }

    public DateOnly? BirthDate { get; set; }
    
    public ICollection<Course>? Courses { get; set; }
}