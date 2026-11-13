using MovieWebApi.AppCore.Abstraction.Repositories;
using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Infrastructure.Services;

public class MovieService(IMovieDataContext DataContext) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return DataContext.GetContext();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return DataContext.GetContext().Where(m => m.Id == id).FirstOrDefault();
    }

    public async Task<int> AddAsync(Movie movie)
    {
        movie.Id = DataContext.GetContext().Count() + 1;
        DataContext.GetContext().Add(movie);
        return movie.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Movie? movie = DataContext.GetContext().Where(m => m.Id == id).FirstOrDefault();
        if (movie is null)
            return false;
        else
        {
            int index = DataContext.GetContext().FindIndex(m => m.Id == id);

            if (index is <= 0)
                return false;

            DataContext.GetContext().RemoveAt(index);
            return true;
        }
    }
}
