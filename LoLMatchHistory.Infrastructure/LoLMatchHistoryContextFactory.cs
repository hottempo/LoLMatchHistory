using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LoLMatchHistory.Infrastructure
{
    public class LoLMatchHistoryContextFactory : IDesignTimeDbContextFactory<LoLMatchHistoryContext>
    {
        public LoLMatchHistoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<LoLMatchHistoryContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(
    "Server=(localdb)\\MSSQLLocalDB;Database=LoLMatchHistory;Trusted_Connection=True;"
);


            return new LoLMatchHistoryContext(optionsBuilder.Options);
        }
    }
}
