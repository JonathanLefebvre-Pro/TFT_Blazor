using MovieWebApi.Domain.Entities;
using MovieWebApi.Dtos;

namespace MovieWebApi.Mappers;

public static class DtoMappers
{
    public static PersonDto ToDto(this Person person)
    {
        return new PersonDto() { FirstName = person.FirstName, LastName = person.LastName };
    }

    public static Person ToEntity(this PersonDto dto)
    {
        return new Person(dto.FirstName, dto.LastName);
    }

    public static IEnumerable<PersonDto> ToDtos(this IEnumerable<Person> persons)
    {
        List<PersonDto> dtos = new List<PersonDto>();
        foreach (Person person in persons)
        {
            dtos.Add(person.ToDto());
        }
        return dtos;
    }

    public static IEnumerable<Person> ToEntities(this IEnumerable<PersonDto> dtos)
    {
        List<Person> entities = new List<Person>();
        foreach (PersonDto dto in dtos)
        {
            entities.Add(dto.ToEntity());
        }
        return entities;
    }

    public static MovieDto ToDto(this Movie movie)
    {
        return new MovieDto()
        {
            Id = movie.Id,
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Description = movie.Description,
            Score = movie.Score,
            Duration = movie.Duration,
            ImageUrl = movie.ImageUrl,
            Directors = movie.Directors.ToDtos(),
            Writers = movie.Writers.ToDtos(),
            Actors = movie.Actors.ToDtos(),
            Categories = movie.Categories,
        };
    }

    public static Movie ToEntity(this AddMovieDto dto)
    {
        return new Movie()
        {
            Title = dto.Title,
            ReleaseDate = dto.ReleaseDate,
            Description = dto.Description,
            Score = dto.Score,
            Duration = dto.Duration,
            ImageUrl = dto.ImageUrl,
            Directors = dto.Directors.ToEntities(),
            Writers = dto.Writers.ToEntities(),
            Actors = dto.Actors.ToEntities(),
            Categories = dto.Categories,
        };
    }

    public static IEnumerable<MovieDto> ToDtos(this IEnumerable<Movie> movies)
    {
        List<MovieDto> dtos = new List<MovieDto>();
        foreach (Movie movie in movies)
        {
            dtos.Add(movie.ToDto());
        }
        return dtos;
    }
}
