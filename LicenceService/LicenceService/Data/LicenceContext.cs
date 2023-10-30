using LicenceService.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenceService.Data
{
    public class LicenceContext:DbContext
    {
        public LicenceContext(DbContextOptions<LicenceContext> options) : base(options) 
        { 
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<LicencePurchase> LicencePurchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Licence>().ToTable("Licence");
            modelBuilder.Entity<LicencePurchase>().ToTable("LicencePurchase");

            // Configure the relationship between Company and LicencePurchase
            modelBuilder.Entity<Company>()
                .HasMany(company => company.LicencePurchases)
                .WithOne(purchase => purchase.Company)
                .HasForeignKey(purchase => purchase.CompanyId);

            // Configure the relationship between Licence and LicencePurchase
            modelBuilder.Entity<Licence>()
                .HasMany(licence => licence.LicencePurchases)
                .WithOne(purchase => purchase.Licence)
                .HasForeignKey(purchase => purchase.LicenceId);
        }
    }
}
