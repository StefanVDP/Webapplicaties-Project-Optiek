using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using Project_Optiek.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_Optiek.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountType> AccountTypes { get; set;}
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
            modelBuilder.Entity<AccountType>().ToTable("AccountType");
            modelBuilder.Entity<AccountType>().Property(p => p.Naam).IsRequired();

            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<Bestelling>().Property(p => p.GebruikerID).IsRequired();
            modelBuilder.Entity<Bestelling>().Property(p => p.Besteldatum).IsRequired();

            modelBuilder.Entity<BestellingItem>().ToTable("BestellingItem");
            modelBuilder.Entity<BestellingItem>().Property(p => p.BestellingID).IsRequired();
            modelBuilder.Entity<BestellingItem>().Property(p => p.ProductID).IsRequired();
            modelBuilder.Entity<BestellingItem>().Property(p => p.Aantal).IsRequired();

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(p => p.Naam).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Prijs).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.SterkteID).IsRequired();

            modelBuilder.Entity<Bril>().ToTable("Bril");
            modelBuilder.Entity<Bril>().Property(p => p.BrilType).IsRequired();
            modelBuilder.Entity<Bril>().Property(p => p.ProductID).IsRequired();

            modelBuilder.Entity<LensProduct>().ToTable("LensProduct");
            modelBuilder.Entity<LensProduct>().Property(p => p.LensType).IsRequired();

            modelBuilder.Entity<Sterkte>().ToTable("Sterkte");
            modelBuilder.Entity<Sterkte>().Property(p => p.sterkte).IsRequired();

            modelBuilder.Entity<WinkelwagenItem>().ToTable("WinkelwagenItem");
            modelBuilder.Entity<WinkelwagenItem>().Property(p => p.GebruikerID).IsRequired();
            modelBuilder.Entity<WinkelwagenItem>().Property(p => p.ProductID).IsRequired();
            modelBuilder.Entity<WinkelwagenItem>().Property(p => p.Aantal).IsRequired();
        }
    }
}
