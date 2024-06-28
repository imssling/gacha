using Microsoft.EntityFrameworkCore;

namespace gachaAPI.Models
{
    public partial class gachaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("gacha"));
            }
        }

    }
}
