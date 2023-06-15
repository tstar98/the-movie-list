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
    public Movie AddMovie(Movie param)
    {
        try
        {
            return _context.AddMovie(param);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return null;
        }
    }
    #endregion

    #region Get
    public Movie GetMovie(int id)
    {
        return _context.GetMovie(id);
    }

    public List<Movie> GetMovies()
    {
        return _context.GetMovies();
    }
    #endregion
}
