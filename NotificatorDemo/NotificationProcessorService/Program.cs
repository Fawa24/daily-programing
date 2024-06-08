using NotificationProcessor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<NotificationProcessorService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
