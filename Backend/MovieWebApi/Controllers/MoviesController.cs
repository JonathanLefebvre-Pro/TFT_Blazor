using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Abstraction;
using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMovieRepository MovieService) : ControllerBase
{
    [Route("Get")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Movie> movies = await MovieService.GetMovies();
        if (movies is null || movies.Count() is 0)
            return this.NotFound();

        return this.Ok(movies);
    }
}
