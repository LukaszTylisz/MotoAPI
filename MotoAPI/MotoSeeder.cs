using Microsoft.AspNetCore.Identity;
using MotoAPI.Entitites;

namespace MotoAPI;

public class MotoSeeder
{
    private readonly MotoDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public MotoSeeder(MotoDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Motos.Any())
            {
                var motos = GetMotos();
                _dbContext.Motos.AddRange(motos);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Users.Any())
            {
                var users = GetUsers();
                _dbContext.Users.AddRange(users);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role()
            {
                Name = "User"
            },
            new Role()
            {
                Name = "Manager"
            },
            new Role()
            {
                Name = "Admin"
            },
        };

        return roles;
    }

    private IEnumerable<Moto> GetMotos()
    {
        var motos = new List<Moto>()
        {
            new Moto()
            {
                Name = "Opel Domcar",
                Category = "Cars Seller",
                Description =
                    "Seller of new and used cars Ford & Opel ",
                ContactEmail = "contact@domcar.pl",
                HasService = true,
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "Ford Mustang",
                        Price = 240000M,
                    },

                    new Car()
                    {
                        Model = "Opel Corsa",
                        Price = 60000M
                    },
                },
                Address = new Address()
                {
                    City = "Konin",
                    Street = "Spółdzielców 9A",
                    PostalCode = "62-510"
                }
            },

            new Moto()
            {
                Name = "Green Auto Group",
                Category = "Cars Seller",
                Description =
                    "Seller of new and used Skoda cars ",
                ContactEmail = "contact@green.pl",
                HasService = true,
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "Skoda Octavia",
                        Price = 190000M,
                    },

                    new Car()
                    {
                        Model = "Skoda Fabia",
                        Price = 75000M
                    },
                },
                Address = new Address()
                {
                    City = "Konin",
                    Street = "Poznańska 43A",
                    PostalCode = "62-510"
                }
            }
        };

        return motos;
    }

    private IEnumerable<User> GetUsers()
    {
        var password = "password";

        var users = new List<User>
        {
            new User
            {
                Email = "user@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Nationality = "Polish",
                RoleId = 1,
                PasswordHash = _passwordHasher.HashPassword(null, password)
            },
            new User
            {
                Email = "manager@example.com",
                DateOfBirth = new DateTime(1985, 1, 1),
                Nationality = "American",
                RoleId = 2,
                PasswordHash = _passwordHasher.HashPassword(null, password)
            },
            new User
            {
                Email = "admin@example.com",
                DateOfBirth = new DateTime(1980, 1, 1),
                Nationality = "British",
                RoleId = 3,
                PasswordHash = _passwordHasher.HashPassword(null, password)
            }
        };
        return users;
    }
}