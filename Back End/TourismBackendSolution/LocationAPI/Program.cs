using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Repositories;
using LocationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
});

builder.Services.AddDbContext<TourLocationContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});
builder.Services.AddScoped<ILocationRepo<Country,int ,string> ,CountryRepo>();
builder.Services.AddScoped<ILocationService<Country, int, string>, CountryService>();
builder.Services.AddScoped<ILocationRepo<State, int, string>, StateRepo>();
builder.Services.AddScoped<ILocationService<State, int, string>, StateService>();
builder.Services.AddScoped<ILocationRepo<City, int, string>, CityRepo>();
builder.Services.AddScoped<ILocationService<City, int, string>, CityService>();


Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
