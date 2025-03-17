using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BinOdonto.Data.AppData;

namespace BinOdonto.Data.Factory
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var options = _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
            return new ApplicationDbContext(options);
        }
    }
}
