using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Abstraction;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMovies();
}
