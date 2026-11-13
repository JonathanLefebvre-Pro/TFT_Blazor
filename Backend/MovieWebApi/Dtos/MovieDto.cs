using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Dtos;

public class MovieDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public DateOnly? ReleaseDate { get; init; }
    public string? Description { get; init; }
    public float? Score { get; init; }
    public int? Duration { get; init; }
    public string? ImageUrl { get; init; }
    public IEnumerable<PersonDto> Directors { get; init; } = Enumerable.Empty<PersonDto>();
    public IEnumerable<PersonDto> Writers { get; init; } = Enumerable.Empty<PersonDto>();
    public IEnumerable<PersonDto> Actors { get; init; } = Enumerable.Empty<PersonDto>();
    public IEnumerable<string> Categories { get; init; } = Enumerable.Empty<string>();
}
