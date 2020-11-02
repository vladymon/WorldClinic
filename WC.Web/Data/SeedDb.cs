using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Common.Enums;
using WC.Web.Data.Entities;
using WC.Web.Helpers;

namespace WC.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Vladimir", "Jaco", "vladimir_jaco@hotmail.com", "949140898", "Lima - S.J.L.", UserType.Admin);

        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _userHelper.CheckRoleAsync(UserType.Public.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
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
