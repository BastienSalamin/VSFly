using Microsoft.EntityFrameworkCore;
using VSFly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  // Fait l'injection de d�pendance dans le controlleur
builder.Services.AddDbContext<VSFlyContext>(opt => opt.UseSqlServer(VSFlyContext.ConnectionString)); // Ajoute la connection string

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
