using BlazorApp.Domain.Entities;

namespace BlazorApp.Domain.Dtos;

public class MovieRequestDto
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
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
