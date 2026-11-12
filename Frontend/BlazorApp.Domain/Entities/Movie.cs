namespace BlazorApp.Domain.Entities;

public record Movie(
    int Id,
    string Title,
    DateOnly? ReleaseDate,
    string? Description,
    float? Score,
    int? Duration,
    string? ImageUrl,
    IEnumerable<Person> Directors,
    IEnumerable<Person> Writers,
    IEnumerable<Person> Actors,
    IEnumerable<string> Categories
);
