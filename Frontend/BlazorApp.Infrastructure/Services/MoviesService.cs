using System.Net.Http.Json;
using BlazorApp.AppCore.Abstraction.Repositories;
using BlazorApp.Domain.Dtos;
using BlazorApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Infrastructure.Services;

public class MoviesService(HttpClient Client, ILogger<MoviesService> Logger) : IMoviesRepository
{
    public async Task<IEnumerable<MovieRequestDto>> GetMovies()
    {
        //Call web api
        return await Client.GetFromJsonAsync<IEnumerable<MovieRequestDto>>("/movies/get")
            ?? Enumerable.Empty<MovieRequestDto>();
    }

    public async Task<int> CreateMovie(CreateMovieDto movie)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync<CreateMovieDto>(
            "/movies/create",
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
