namespace TheMovieList.Services;

public class AccountService
{
    private readonly IConfiguration _configuration;

    public AccountService(IConfiguration configuration)
    {
        _configuration = configuration; 
    }
}
