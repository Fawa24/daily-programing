using Lab_1.Interfaces;
using Lab_1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IAuthorsService, AuthorService>();
builder.Services.AddSingleton<IBooksService, BooksService>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
