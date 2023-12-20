using DOTNET_P002.WebAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/jhonata/", () => Jhonata.View());
app.MapGet("/joao/", () => Joao.View());

app.Run();
