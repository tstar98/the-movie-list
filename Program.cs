<<<<<<< Updated upstream
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
=======
using Microsoft.OpenApi.Models;
>>>>>>> Stashed changes
using TheMovieList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
<<<<<<< Updated upstream
builder.Services.AddSingleton<WeatherForecastService>();
=======

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
>>>>>>> Stashed changes

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
