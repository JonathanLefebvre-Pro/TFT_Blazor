using BlazorApp.AppCore.Dtos;
using BlazorApp.Domain.Entities;

namespace BlazorApp.AppCore.Mappers;

public static class DtoMappers
{
    public static Movie ToEntity(this MovieDto dto)
    {
        return new Movie(
            dto.Id,
            dto.Title,
            dto.ReleaseDate,
            dto.Description,
            dto.Score,
            dto.Duration,
            dto.ImageUrl,
            dto.Directors.ToEntities(),
            dto.Writers.ToEntities(),
            dto.Actors.ToEntities(),
            dto.Categories
        );
    }

    public static IEnumerable<Movie> ToEntities(this IEnumerable<MovieDto> dtos)
    {
        List<Movie> movies = new List<Movie>();
        foreach (MovieDto dto in dtos)
        {
            movies.Add(dto.ToEntity());
        }
        return movies;
    }

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
}
