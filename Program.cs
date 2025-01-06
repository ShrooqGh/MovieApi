using MovieApi.Models;
using Microsoft.EntityFrameworkCore;
using MovieApi.MovieServices;
using Microsoft.Extensions.Configuration;
using MovieApi.Repository;
using MovieApi.MovieRepository;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

builder.Services.AddDbContext<MovieContext>(options => 
           options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));


builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieServices, MovieServices>();


builder.Services.AddResponseCaching();


builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("120SecondsDuration",
                             new CacheProfile { Duration = 120 });
});

//SwaggerforDocumentation:GenerateAPIdocs.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movie API",
        Version =
    "v1"
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Global Exception Handling: Handle exceptions
//consistently using middleware.
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext httpContext) =>
{
    var exceptionHandlerFeature =
    httpContext.Features.Get<IExceptionHandlerFeature>();
    var exception = exceptionHandlerFeature?.Error;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

