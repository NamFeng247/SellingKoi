using Microsoft.EntityFrameworkCore;
using SellingKoi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace SellingKoi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<KOI> KOIs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Định nghĩa quan hệ 1-nhiều giữa Farm và KoiProduct
            modelBuilder.Entity<Farm>()
                .HasMany(f => f.KOIs)
                .WithOne(k => k.Farm)
                .HasForeignKey(k => k.FarmID);
        }
    }
}
