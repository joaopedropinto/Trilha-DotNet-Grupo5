using Microsoft.EntityFrameworkCore;
using TechAdvocacia.Application.Services;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILawyerService, LawyerService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ILegalCaseService, LegalCaseService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Services.AddDbContext<TechAdvocaciaDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("TecDb");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

      options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
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
