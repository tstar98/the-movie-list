using Microsoft.Data.Sqlite;
using TheMovieList.Models;

namespace TheMovieList.Data;

public class MovieListContext
{
    private readonly string _connectionStr = "Data Source=data/database.db;";
    private readonly SqliteConnection _connection;

    public MovieListContext() 
    { 
        _connection = new SqliteConnection(_connectionStr);
        _connection.Open();
    }

    ~MovieListContext() 
    {
        _connection.Close();
    }

    #region Get
    public async Task<Movie> GetMovieAsync(int id)
    {
        Movie movie = new Movie();

        using var command = _connection.CreateCommand();
        command.CommandText = $"SELECT id, title, tmdb_id, year FROM movies WHERE id = {id};";

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            movie = new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                TmdbId = reader.GetInt32(2),
                Year = reader.GetInt32(3),
            };
        }

        return movie;
    }

    public async Task<Movie> GetMovieByTmdbIdAsync(int tmdbId)
    {
        Movie movie = new Movie();

        using var command = _connection.CreateCommand();
        command.CommandText = $"SELECT id, title, tmdb_id, year FROM movies WHERE tmdb_id = {tmdbId};";

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            movie = new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                TmdbId = reader.GetInt32(2),
                Year = reader.GetInt32(3),
            };
        }

        return movie;
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        List<Movie> movies = new List<Movie>();

        using var command = _connection.CreateCommand();
        command.CommandText = "SELECT id, title, tmdb_id, year FROM movies;";
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            movies.Add(new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                TmdbId = reader.GetInt32(2),
                Year = reader.GetInt32(3),
            }) ;
        }

        return movies;
    }
    #endregion

    #region Add
    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"INSERT INTO movies (title, tmdb_id, year) VALUES('{movie.Title}', {movie.TmdbId}, {movie.Year});";
        return await GetMovieByTmdbIdAsync(movie.TmdbId);
    }
    #endregion
}
