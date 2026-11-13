using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Presentation.FormModels;

[ValidatableType]
public class PersonForm
{
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
}
