using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;

namespace WC.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Perú",
                    Departments = new List<Department>
                {
                    new Department
                    {
                        Name = "Lima",
                        Cities = new List<City>
                        {
                            new City { Name = "Lima" },
                            new City { Name = "Barranca" },
                            new City { Name = "Huacho" }
                        }
                    },
                    new Department
                    {
                        Name = "Arequipa",
                        Cities = new List<City>
                        {
                            new City { Name = "Camana" },
                            new City { Name = "Castilla" }
                        }
                    },
                    new Department
                    {
                        Name = "Cusco",
                        Cities = new List<City>
                        {
                            new City { Name = "Paucartambo" },
                            new City { Name = "Urubamba" },
                            new City { Name = "Espinar" }
                        }
                    }
                }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    Departments = new List<Department>
                {
                    new Department
                    {
                        Name = "Antioquia",
                        Cities = new List<City>
                        {
                            new City { Name = "Medellín" },
                            new City { Name = "Envigado" },
                            new City { Name = "Itagüí" }
                        }
                    },
                    new Department
                    {
                        Name = "Bogotá",
                        Cities = new List<City>
                        {
                            new City { Name = "Bogotá" }
                        }
                    },
                    new Department
                    {
                        Name = "Valle del Cauca",
                        Cities = new List<City>
                        {
                            new City { Name = "Calí" },
                            new City { Name = "Buenaventura" },
                            new City { Name = "Palmira" }
                        }
                    }
                }
                });

                await _context.SaveChangesAsync();
            }
        }
    }

}
