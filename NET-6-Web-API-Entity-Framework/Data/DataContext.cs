﻿using ProductProje.API.Core;

namespace ProductProje.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ProductEntity> productEntities { get; set; }

    }
   

}
