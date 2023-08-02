#nullable disable
using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Hotels_RoomsAPI.Repositories;
using Hotels_RoomsAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelsContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});
builder.Services.AddScoped<IHotelRepo<Hotel, int>,HotelRepo>();
builder.Services.AddScoped<IRoomRepo<Room, int>, RoomRepo>();
builder.Services.AddScoped<IHotelService<Hotel, int>, HotelService>();
builder.Services.AddScoped<IRoomService<Room, int>, RoomService>();

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
