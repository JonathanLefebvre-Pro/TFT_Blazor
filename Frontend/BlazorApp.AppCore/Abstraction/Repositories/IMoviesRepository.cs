using BlazorApp.Domain.Entities;

namespace BlazorApp.AppCore.Abstraction.Repositories;

public interface IMoviesRepository
{
    Task<IEnumerable<Movie>> GetMovies();
}
