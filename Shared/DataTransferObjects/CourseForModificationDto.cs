using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record CourseForModificationDto
{
    [Required]
    [MaxLength(120, ErrorMessage = "Maximum length of Name is 120")]
    public required string Name { get; set; }

    [Required]
    [MaxLength(60, ErrorMessage = "Maximum length of Instructor is 60")]
    public required string Instructor { get; set; }
};