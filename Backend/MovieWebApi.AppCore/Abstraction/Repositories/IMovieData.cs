using MovieWebApi.Domain.Entities;

namespace MovieWebApi.AppCore.Abstraction.Repositories;

public interface IMovieDataContext
{
    List<Movie> GetContext();
}
