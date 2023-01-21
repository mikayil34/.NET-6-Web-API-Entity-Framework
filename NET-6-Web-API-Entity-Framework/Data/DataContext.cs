using NET_6_Web_API_Entity_Framework.Core;
using ProductProje.API.Core;

namespace ProductProje.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoodes { get; set; }

    }
   

}
