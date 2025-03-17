using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BinOdonto.Application.Interfaces;
using BinOdonto.Application.Services;
using BinOdonto.Data.AppData;
using BinOdonto.Data.Factory;
using BinOdonto.Data.Repository;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Service;

namespace Revisao.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => {
                //options.UseOracle(configuration.GetConnectionString("Oracle"));
                options.UseMongoDB(configuration.GetConnectionString("Mongodb") ?? string.Empty, "Aula");
            });

            services.AddTransient<IDbContextFactory, DbContextFactory>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteApplication, ClienteApplication>();

            services.AddTransient<IEnderecoService, EnderecoService>();


        }
    }
}
