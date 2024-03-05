using Microsoft.EntityFrameworkCore;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Domain.Aggregates.Products.Models;
using PfMsSalesPlatform.Domain.Aggregates.SalesBody.Models;
using PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models;

namespace PfMsSalesPlatform.Infrastructure.Context
{
    public class SalesDBContext : DbContext
    {
        public SalesDBContext(DbContextOptions<SalesDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SaleHeader> SaleHeaders { get; set; }
        public DbSet<Salebody> Salebodys { get; set; }
    }
}
