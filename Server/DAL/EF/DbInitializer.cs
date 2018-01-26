using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class DbInitializer
    {
        private ClinicContext _context;

        public DbInitializer(ClinicContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Roles.Any())
            {
                _context.AddRange(roles);
                await _context.SaveChangesAsync();
            }

            if (!_context.Users.Any())
            {
                _context.AddRange(users);
                await _context.SaveChangesAsync();
            }
        }

        List<Role> roles = new List<Role>
        {
            new Role{ Name="admin" },
            new Role{ Name="patient" },
            new Role{ Name="doctor" },
        };
        List<User> users = new List<User>
        {
            new User{ Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=", RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995-01-01), PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
            new User{ Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=", RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995-02-02), PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
            new User{ Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=", RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995-03-03), PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
        };
    }
}
