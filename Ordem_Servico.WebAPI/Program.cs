using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Application.Services;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrdemServicoContext>();
builder.Services.AddScoped<IOrdemServicoService, IOrdemServicoService>();
builder.Services.AddScoped<ITecnicoService, ITecnicoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEquipamentoService, IEquipamentoService>();
builder.Services.AddScoped<IServicoService, IServicoService>();

builder.Services.AddDbContext<OrdemServicoContext>(options =>
{
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
