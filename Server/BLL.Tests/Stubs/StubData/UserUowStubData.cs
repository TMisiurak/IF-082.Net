using ProjectCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Tests.Stubs.StubData
{
    public static class UserUowStubData
    {
        private static List<User> _users;

        public static List<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new List<User>
                    {
                        new User{ Id = 1, Email = "email1@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                            RoleId = 1, FullName = "Full Name 1", Address = "Address 1", BirthDay = new DateTime(1995, 1, 1),
                            PhoneNumber = "0123456781", Sex = "mal", Image = "imagesrc 1" },
                        new User{ Id = 2, Email = "email2@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                            RoleId = 2, FullName = "Full Name 2", Address = "Address 2", BirthDay = new DateTime(1995, 2, 2),
                            PhoneNumber = "0123456782", Sex = "fem", Image = "imagesrc 2" },
                        new User{ Id = 3, Email = "email3@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                            RoleId = 3, FullName = "Full Name 3", Address = "Address 3", BirthDay = new DateTime(1995, 3, 3),
                            PhoneNumber = "0123456783", Sex = "fem", Image = "imagesrc 3" },
                        new User{ Id = 4, Email = "email4@e.com", Password = "fNOLDzjY9ITa8f7/a1hbE9aHeiE07xzdsCH4PKirJ9E=",
                            RoleId = 4, FullName = "Full Name 4", Address = "Address 4", BirthDay = new DateTime(1995, 4, 4),
                            PhoneNumber = "0123456784", Sex = "mal", Image = "imagesrc 4" },
                    };
                }
                return _users;
            }
        }
    }
}
