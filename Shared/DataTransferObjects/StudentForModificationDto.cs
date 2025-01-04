using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record StudentForModificationDto
{
        
    [Required]
    [MaxLength(60, ErrorMessage = "Maximum length of FirstName is 60")]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(60, ErrorMessage = "Maximum length of LastName is 60")]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    public DateOnly? BirthDate { get; set; }
};