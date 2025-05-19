using Microsoft.EntityFrameworkCore;
using BinOdonto.Application.Interfaces;
using BinOdonto.Service;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Data.AppData;
using BinOdonto.Data.Repositories;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados com ApplicationDbContext e Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração de dependências (injeção de dependência)
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
builder.Services.AddScoped<IFuncionarioApplicationService, FuncionarioApplicationService>();

// Adicionando o Singleton para gerenciar configurações
builder.Services.AddSingleton<IConfiguracaoService, ConfiguracaoService>();

// Serviços de recomendação e integração externa
builder.Services.AddScoped<FuncionarioRecomendadoService>(); // Serviço de IA/recomendação
builder.Services.AddHttpClient<IViaCepService, ViaCepService>(); // Cliente HTTP para ViaCEP

// Configuração de suporte para controllers e API
builder.Services.AddControllers();

// Configuração do Swagger com anotações
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Ativa suporte a [SwaggerOperation]
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BinOdonto API",
        Version = "v1",
        Description = "API RESTful para gerenciamento de clientes e funcionários com recomendação via CEP"
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
