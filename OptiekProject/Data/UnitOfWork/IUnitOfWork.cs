using Project_Optiek.Data.Repository;
using Project_Optiek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Bestelling> BestellingRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Bril> BrilRepository { get; }
        IGenericRepository<LensProduct> LensProductRepository { get; }
        IGenericRepository<Gebruiker> GebruikerRepository { get; }
        IGenericRepository<Sterkte> SterkteRepository { get; }
        IGenericRepository<WinkelwagenItem> WinkelwagenItemRepository { get; }
        Task Save();
    }
}
