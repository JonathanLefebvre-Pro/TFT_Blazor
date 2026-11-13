using System.Net.Http.Json;
using BlazorApp.AppCore.Abstraction.Repositories;
using BlazorApp.AppCore.Dtos;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Infrastructure.Services;

public class MoviesService(HttpClient Client, ILogger<MoviesService> Logger) : IMoviesRepository
{
    public async Task<IEnumerable<MovieDto>> GetMovies()
    {
        //Call web api
        return await Client.GetFromJsonAsync<IEnumerable<MovieDto>>("/movies/getallasync")
            ?? Enumerable.Empty<MovieDto>();
    }

    public async Task<int> CreateMovie(AddMovieDto movie)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync<AddMovieDto>(
            "/movies/addasync",
            movie
        );
        if (response.IsSuccessStatusCode)
        {
            var id = await response.Content.ReadAsStringAsync();
            Logger.LogInformation(id);
            return int.Parse(id);
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            Logger.LogWarning(error);
            return 0;
        }
    }
}
