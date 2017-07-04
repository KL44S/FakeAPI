using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class UserMemoryDao : UserDao
    {
        private static IList<User> _users = new List<User>()
        {
            new User()
            {
                Cuit = "12345678",
                Name = "Juan",
                Lastname = "Perez",
                Password = "12345678",
                RoleId = 1
            },
            new User()
            {
                Cuit = "12345678910",
                Name = "Alguien",
                Lastname = "Mas",
                Password = "12345678910",
                RoleId = 2
            },
            new User()
            {
                Cuit = "63466345555",
                Name = "Agustin",
                Lastname = "Binci",
                Password = "63466345555",
                RoleId = 2
            },
            new User()
            {
                Cuit = "75543212233",
                Name = "Guido",
                Lastname = "Armando",
                Password = "75543212233",
                RoleId = 3
            }
        };


        public override void Create(User User)
        {
            _users.Add(User);
        }

        public override IEnumerable<User> GetAll()
        {
            return _users;
        }

        public override User GetUserByCuit(string Cuit)
        {
            User FoundUser = _users.FirstOrDefault(User => User.Cuit.Equals(Cuit));

            if (FoundUser != null)
                return FoundUser;

            throw new EntityNotFoundException();
        }

        public override User GetUserByCuitAndPassword(string Cuit, string Password)
        {
            User FoundUser = _users.FirstOrDefault(User => User.Cuit.Equals(Cuit) && User.Password.Equals(Password));

            if (FoundUser != null)
                return FoundUser;

            throw new EntityNotFoundException();
        }

        public override void Update(User User)
        {
            User FoundUser = this.GetUserByCuit(User.Cuit);

            FoundUser.Name = User.Name;
            FoundUser.Lastname = User.Lastname;
            FoundUser.RoleId = User.RoleId;
        }
    }
}
