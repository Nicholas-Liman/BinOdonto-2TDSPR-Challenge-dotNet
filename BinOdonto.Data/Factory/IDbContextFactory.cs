using BinOdonto.Data.AppData;

namespace BinOdonto.Data.Factory
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext();
    }
}
