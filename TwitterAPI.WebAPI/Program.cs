using Microsoft.EntityFrameworkCore;
using TwitterAPI.Application.Options;
using TwitterAPI.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionStringOptions>(
    builder.Configuration.GetSection(ConnectionStringOptions.Position));

var config = builder.Configuration;
var connString = config.GetSection(nameof(ConnectionStringOptions))
    .Get<ConnectionStringOptions>().TweetDbConnectionString;

builder.Services.AddDbContext<TweetDbContext>(option =>
{
    option.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();