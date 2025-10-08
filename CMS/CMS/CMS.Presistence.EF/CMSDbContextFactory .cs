using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CMS.Presistence.EF
{
    public class CMSDbContextFactory : IDesignTimeDbContextFactory<CMSDbContext>
    {
        public CMSDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CMSDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CMSDbContext(optionsBuilder.Options);
        }
    }
}