using ResTIConnect.Application.Services;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ResTIConnectContext>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<ISistemaService, SistemaService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddControllers();
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
