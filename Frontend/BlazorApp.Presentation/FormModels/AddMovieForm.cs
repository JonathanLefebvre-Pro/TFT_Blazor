using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Presentation.FormModels;

[ValidatableType]
public class AddMovieForm
{
    [Required]
    [MinLength(1)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateOnly ReleaseDate { get; set; }

    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 10)]
    public float Score { get; set; }

    [Required]
    public int Duration { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<PersonForm> Directors { get; set; } = new List<PersonForm>();
    public List<PersonForm> Writers { get; set; } = new List<PersonForm>();
    public List<PersonForm> Actors { get; set; } = new List<PersonForm>();
    public List<string> Categories { get; set; } = new List<string>();
}
