using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheMovieList.Services;

namespace TheMovieList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    IConfiguration _config;
    AccountService _service;

    public AccountController(IConfiguration config, AccountService service) 
    {
        _config = config;
        _service = service;
    }

    [HttpGet("health")]
    public ActionResult<bool> GetHealth()
    {
        return true;
    }
}
