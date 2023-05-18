using MotoAPI.Entitites;

namespace MotoAPI;

public class MotoSeeder
{
    private readonly MotoDbContext _dbContext;

    public MotoSeeder(MotoDbContext dbContext)
    {
        _dbContext = dbContext;
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
}