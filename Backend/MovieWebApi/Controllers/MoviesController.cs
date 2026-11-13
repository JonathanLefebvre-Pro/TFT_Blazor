using Microsoft.AspNetCore.Mvc;
using MovieWebApi.AppCore.Abstraction.Repositories;
using MovieWebApi.Domain.Entities;
using MovieWebApi.Dtos;
using MovieWebApi.Mappers;

namespace MovieWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMovieRepository MovieService) : ControllerBase
{
    [Route("GetAllAsync")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<Movie> movies = await MovieService.GetAllAsync();
        if (movies is null || movies.Count() is 0)
            return this.NotFound();

        return this.Ok(movies.ToDtos());
    }

    [Route("GetByIdAsync/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Movie? movie = await MovieService.GetByIdAsync(id);
        if (movie is null)
            return this.NotFound();

        return this.Ok(movie.ToDto());
    }

    [Route("AddAsync")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddMovieDto dto)
    {
        int result = await MovieService.AddAsync(dto.ToEntity());
        return result != 0 ? this.Ok(result) : this.BadRequest();
    }
}
