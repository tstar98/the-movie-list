using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheMovieList.Models;
using TheMovieList.Services;

namespace TheMovieList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieListController : ControllerBase
{
    MovieListService _service;

    public MovieListController(MovieListService service) 
    {
        _service = service;
    }

    #region Create
    [HttpPost("v1/movies")]
    public ActionResult<Movie> AddMovie([FromBody]Movie param)
    {
        Movie movie = _service.AddMovie(param);
        if (movie == null)
            return StatusCode(503);
        return Ok(movie);
    }
    #endregion

    #region Get
    [HttpGet("v1/movies")]
    public ActionResult GetMovie([FromQuery(Name = "id")] int? id)
    {
        if (id != null)
            return Ok(_service.GetMovie((int)id));
        return Ok(_service.GetMovies());
    }
    #endregion

    #region Update

    #endregion

    #region Delete

    #endregion
}
