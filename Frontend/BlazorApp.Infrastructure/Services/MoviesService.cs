using System.Net.Http.Json;
using BlazorApp.AppCore.Abstraction.Repositories;
using BlazorApp.Domain.Entities;

namespace BlazorApp.Infrastructure.Services;

public class MoviesService(HttpClient Client) : IMoviesRepository
{
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        //Call web api
        return await Client.GetFromJsonAsync<IEnumerable<Movie>>("/movies/get")
            ?? Enumerable.Empty<Movie>();
    }
}
