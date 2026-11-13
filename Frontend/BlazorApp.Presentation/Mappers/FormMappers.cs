using BlazorApp.AppCore.Dtos;
using BlazorApp.Domain.Entities;
using BlazorApp.Presentation.FormModels;

namespace BlazorApp.Presentation.Mappers;

public static class FormMappers
{
    public static IEnumerable<Person> ToEntities(this List<PersonForm> form)
    {
        List<Person> persons = new List<Person>();
        foreach (PersonForm personForm in form)
        {
            persons.Add(new Person(personForm.FirstName, personForm.LastName));
        }
        return persons;
    }

    public static AddMovieDto ToDto(this AddMovieForm form)
    {
        return new AddMovieDto()
        {
            Title = form.Title,
            ReleaseDate = form.ReleaseDate,
            Description = form.Description,
            Score = form.Score,
            Duration = form.Duration,
            ImageUrl = form.ImageUrl,
            Directors = form.Directors.ToEntities(),
            Writers = form.Writers.ToEntities(),
            Actors = form.Actors.ToEntities(),
            Categories = form.Categories,
        };
    }
}
