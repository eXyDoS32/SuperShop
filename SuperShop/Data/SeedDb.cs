using SuperShop.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()  //cria base de dados caso ela nao esteja criada
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                AddProduct("Iphone X");
                AddProduct("Joginho da pinta");
                AddProduct("Rato Telecomandado");
                AddProduct("Ventoinha do chines");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name) //popular com as coisas
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100)
            });
        }
    }
}

//isto serve para dar "seed" a database, caso a base nao existe ele cria e popula a base de dados com informacao e caso ela existe isto nao faz nada (:
