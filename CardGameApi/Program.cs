using CardGameApi.src.Domain.Data;
using CardGameApi.src.Domain.Service;
using Microsoft.EntityFrameworkCore;
using CardGameApi.src.Entities;
using CardGameApi.src.Domain.Interface;
using CardGameApi.src.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5174")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<GameService, GameService>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GameDbContext>(options => options.UseSqlite("Data Source=game.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
