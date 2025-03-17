using Microsoft.EntityFrameworkCore;
using BinOdonto.Application.Interfaces;
using BinOdonto.Service;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Data.AppData;
using BinOdonto.Data.Repositories;
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

// Configuração de suporte para controllers e API
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita o Swagger antes do roteamento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Exibe página detalhada de erro no ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BinOdonto API v1");
        c.RoutePrefix = string.Empty; // Isso faz com que o Swagger abra direto na raiz do site
    });
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Redireciona para a página de erro customizada
}

// Habilita arquivos estáticos (CSS, JS, imagens etc.)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuração das rotas para API
app.MapControllers();

// Remove o roteamento MVC, pois não há mais views no projeto
// Se precisar manter MVC, garanta que ele não conflite com a API
/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
*/

// Abre automaticamente o Swagger no navegador ao iniciar a API
var swaggerUrl = "https://localhost:7214/swagger";
Process.Start(new ProcessStartInfo { FileName = swaggerUrl, UseShellExecute = true });

// Inicializa o aplicativo
app.Run();
