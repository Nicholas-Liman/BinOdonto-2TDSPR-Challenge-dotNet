using Microsoft.EntityFrameworkCore;
using BinOdonto.Application.Interfaces;
using BinOdonto.Service;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Data.AppData;
using BinOdonto.Data.Repositories;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados com ApplicationDbContext e Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o de depend�ncias (inje��o de depend�ncia)
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
builder.Services.AddScoped<IFuncionarioApplicationService, FuncionarioApplicationService>();

// Adicionando o Singleton para gerenciar configura��es
builder.Services.AddSingleton<IConfiguracaoService, ConfiguracaoService>();

// Servi�os de recomenda��o e integra��o externa
builder.Services.AddScoped<FuncionarioRecomendadoService>(); // Servi�o de IA/recomenda��o
builder.Services.AddHttpClient<IViaCepService, ViaCepService>(); // Cliente HTTP para ViaCEP

// Configura��o de suporte para controllers e API
builder.Services.AddControllers();

// Configura��o do Swagger com anota��es
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Ativa suporte a [SwaggerOperation]
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BinOdonto API",
        Version = "v1",
        Description = "API RESTful para gerenciamento de clientes e funcion�rios com recomenda��o via CEP"
    });
});

var app = builder.Build();

// Habilita o Swagger antes do roteamento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BinOdonto API v1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
