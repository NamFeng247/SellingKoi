using Microsoft.EntityFrameworkCore;
using SellingKoi.Models;
using SellingKoi.Models.Entities;

namespace SellingKoi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<KOI> KOIs { get; set; }
    }
}
