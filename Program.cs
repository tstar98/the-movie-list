using Microsoft.OpenApi.Models;
using TheMovieList.Data;
using TheMovieList.Services;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add Service classes 
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<MovieListService>();
builder.Services.AddSingleton<MovieListContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(_ =>
{
    _.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "The Movie List API" });
});
builder.Services.AddMvcCore().AddApiExplorer();

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
