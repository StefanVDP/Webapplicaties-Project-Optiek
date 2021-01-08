using Project_Optiek.Data.Repository;
using Project_Optiek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Bestelling> bestellingRepository;
        private IGenericRepository<Product> productRepository;
        private IGenericRepository<Bril> brilRepository;
        private IGenericRepository<LensProduct> lensProductRepository;
        private IGenericRepository<Gebruiker> gebruikerRepository;
        private IGenericRepository<Sterkte> sterkteRepository;
        private IGenericRepository<WinkelwagenItem> winkelwagenItemRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public IGenericRepository<Bestelling> BestellingRepository
        {
            get
            {
                if (this.bestellingRepository == null)
                {
                    this.bestellingRepository = new GenericRepository<Bestelling>(_context);
                }
                return bestellingRepository;
            }
        }
        public IGenericRepository<Product> ProductRepository
        {
            get 
            { 
                if(this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }
        public IGenericRepository<Bril> BrilRepository
        {
            get
            {
                if (this.brilRepository == null)
                {
                    this.brilRepository = new GenericRepository<Bril>(_context);
                }
                return brilRepository;
            }
        }
        public IGenericRepository<LensProduct> LensProductRepository
        {
            get
            {
                if (this.lensProductRepository == null)
                {
                    this.lensProductRepository = new GenericRepository<LensProduct>(_context);
                }
                return lensProductRepository;
            }
        }
        public IGenericRepository<Gebruiker> GebruikerRepository
        {
            get
            {
                if (this.gebruikerRepository == null)
                {
                    this.gebruikerRepository = new GenericRepository<Gebruiker>(_context);
                }
                return gebruikerRepository;
            }
        }
        public IGenericRepository<Sterkte> SterkteRepository
        {
            get
            {
                if (this.sterkteRepository == null)
                {
                    this.sterkteRepository = new GenericRepository<Sterkte>(_context);
                }
                return sterkteRepository;
            }
        }
        public IGenericRepository<WinkelwagenItem> WinkelwagenItemRepository
        {
            get
            {
                if (this.winkelwagenItemRepository == null)
                {
                    this.winkelwagenItemRepository = new GenericRepository<WinkelwagenItem>(_context);
                }
                return winkelwagenItemRepository;
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
