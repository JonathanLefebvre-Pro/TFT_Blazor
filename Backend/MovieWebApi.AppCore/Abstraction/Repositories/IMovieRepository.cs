using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Abstraction;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> Get();
    Task<Movie?> Get(int id);
    Task<int> Add(Movie movie);
    Task<bool> Delete(int id);
}
