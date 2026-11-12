using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Abstraction;
using MovieWebApi.Domain.Entities;
using MovieWebApi.Dtos;

namespace MovieWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMovieRepository MovieService) : ControllerBase
{
    [Route("Get")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Movie> movies = await MovieService.Get();
        if (movies is null || movies.Count() is 0)
            return this.NotFound();

        return this.Ok(movies);
    }

    [Route("Get/{id}")]
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        Movie? movie = await MovieService.Get(id);
        if (movie is null)
            return this.NotFound();

        return this.Ok(movie);
    }

    [Route("Create")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = new Movie()
        {
            Title = movieDto.Title,
            ReleaseDate = movieDto.ReleaseDate,
            Description = movieDto.Description,
            Score = movieDto.Score,
            Duration = movieDto.Duration,
            ImageUrl = movieDto.ImageUrl,
            Directors = movieDto.Directors,
            Writers = movieDto.Writers,
            Actors = movieDto.Actors,
            Categories = movieDto.Categories,
        };

        int result = await MovieService.Add(movie);
        return result != 0 ? this.Ok(result) : this.BadRequest();
    }
}
