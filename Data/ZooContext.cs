namespace ZooApplicationV2.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using System.Threading.Tasks;
    using ZooApplicationV2.Models;

    public class ZooContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }

        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }

}
