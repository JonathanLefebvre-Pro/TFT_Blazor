using BlazorApp.Domain.Dtos;
using BlazorApp.Domain.Entities;

namespace BlazorApp.AppCore.Abstraction.Repositories;

public interface IMoviesRepository
{
    Task<IEnumerable<MovieRequestDto>> GetMovies();
    Task<int> CreateMovie(CreateMovieDto movie);
}
