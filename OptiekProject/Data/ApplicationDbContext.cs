using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Optiek.Models;
using Project_Optiek.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace Project_Optiek.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<BestellingItem> bestellingItems { get; set; }
        public DbSet<Bril> Brillen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<LensProduct> LensProducten { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Sterkte> Sterkten { get; set; }
        public DbSet<WinkelwagenItem> WinkelwagenItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountType>().ToTable("AccountType");
            modelBuilder.Entity<AccountType>().Property(p => p.Naam).IsRequired();

            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<Bestelling>().Property(p => p.Besteldatum).IsRequired();

            modelBuilder.Entity<BestellingItem>().ToTable("BestellingItem");

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(p => p.Naam).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Prijs).IsRequired();
            modelBuilder.Entity<Product>().Property(e => e.Prijs).HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<Product>().HasDiscriminator<string>("Product_Type").HasValue<LensProduct>("lens").HasValue<Bril>("Bril");

            modelBuilder.Entity<Sterkte>().ToTable("Sterkte");

            modelBuilder.Entity<WinkelwagenItem>().ToTable("WinkelwagenItem");

            modelBuilder.Entity<CustomUser>().HasOne(k => k.Gebruiker).WithOne(c => c.CustomUser).HasForeignKey<Gebruiker>(k => k.UserID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=edudb.thomasmore.be,3000;Database=PR_r0595358;User Id=pr__r0595358;Password=pr4you");
        }
    }
}
