using Microsoft.EntityFrameworkCore;
using PracticeProj.BookDbContext;
using PracticeProj.Models;
using PracticeProj.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddDbContext<BooksDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]));
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
