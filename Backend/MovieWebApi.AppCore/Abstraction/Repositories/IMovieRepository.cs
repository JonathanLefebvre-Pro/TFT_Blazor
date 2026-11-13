using MovieWebApi.Domain.Entities;

namespace MovieWebApi.AppCore.Abstraction.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(int id);
    Task<int> AddAsync(Movie movie);
    Task<bool> DeleteAsync(int id);
}
