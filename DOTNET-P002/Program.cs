using DOTNET_P002.WebAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/valber/", () => Valber.View());

app.Run();