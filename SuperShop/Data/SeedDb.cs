using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;
using SuperShop.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()  //cria base de dados caso ela nao esteja criada
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsyn("DiogoT@gmail.com");
            if(user == null)
            {
                user = new User
                {
                    FirstName = "Diogo",
                    LastName = "Tome",
                    Email = "DiogoT@gmail.com",
                    UserName = "DiogoT@gmail.com",
                    PhoneNumber = "21231312"
                };
                var result = await _userHelper.AddUserAsync(user,"123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Products.Any())
            {
                AddProduct("Iphone X",user);
                AddProduct("Joginho da pinta", user);
                AddProduct("Rato Telecomandado", user);
                AddProduct("Ventoinha do chines", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name,User user) //popular com as coisas
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}

//isto serve para dar "seed" a database, caso a base nao existe ele cria e popula a base de dados com informacao e caso ela existe isto nao faz nada (:
