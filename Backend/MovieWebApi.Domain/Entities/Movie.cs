namespace MovieWebApi.Domain.Entities;

public record Movie(
    int Id,
    string Title,
    DateOnly ReleaseDate,
    string Description,
    float Score,
    int Duration,
    string ImageUrl,
    List<Person> Directors,
    List<Person> Writers,
    List<Person> Actors,
    List<string> Categories
);
