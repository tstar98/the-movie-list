using TheMovieList.Data;
using TheMovieList.Models;

namespace TheMovieList.Services;

public class MovieListService
{
    private readonly MovieListContext _context;
    private readonly ILogger _logger;

    public MovieListService(MovieListContext context, ILoggerFactory loggerFacotry)
    {
        _context = context;
        _logger = loggerFacotry.CreateLogger<MovieListService>();
    }

    #region Create
    public async Task<Movie> AddMovieAsync(Movie param)
    {
        try
        {
            return await _context.AddMovieAsync(param);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return null;
        }
    }
    #endregion

    #region Get
    public async Task<Movie> GetMovieAsync(int id)
    {
        return await _context.GetMovieAsync(id);
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        return await _context.GetMoviesAsync();
    }
    #endregion
}
