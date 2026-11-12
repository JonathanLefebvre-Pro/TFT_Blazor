using System.ComponentModel.DataAnnotations;
using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Dtos;

public class CreateMovieDto
{
    [Required]
    public required string Title { get; init; }
    public DateOnly? ReleaseDate { get; init; }
    public string? Description { get; init; }
    public float? Score { get; init; }
    public int? Duration { get; init; }
    public string? ImageUrl { get; init; }
    public IEnumerable<Person> Directors { get; init; } = Enumerable.Empty<Person>();
    public IEnumerable<Person> Writers { get; init; } = Enumerable.Empty<Person>();
    public IEnumerable<Person> Actors { get; init; } = Enumerable.Empty<Person>();
    public IEnumerable<string> Categories { get; init; } = Enumerable.Empty<string>();
}
