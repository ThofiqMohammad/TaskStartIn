using Microsoft.EntityFrameworkCore;
using WApiDemo.Comp.Models.EntityModels;

namespace WApiDemo.Comp.WApiDemoDbContext
{
    public class WApiDbContext : DbContext
    {
        public WApiDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country() { Name="India", ShortName="IN", Id = 1},
                new Country() { Name="Saudi Arabia", ShortName="KSA", Id=2}
                );
            modelBuilder.Entity<Hotel>().HasData(new Hotel() { Id=1, Name="Ziara", Address="YSR", Rating=3.9, CountryId=1});
        }
    }
}
