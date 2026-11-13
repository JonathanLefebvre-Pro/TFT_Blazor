using BlazorApp.AppCore.Dtos;

namespace BlazorApp.AppCore.Abstraction.Repositories;

public interface IMoviesRepository
{
    Task<IEnumerable<MovieDto>> GetMovies();
    Task<int> CreateMovie(AddMovieDto movie);
}
