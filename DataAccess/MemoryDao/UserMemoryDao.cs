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
                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                RoleId = 1
            },
            new User()
            {
                Cuit = "12345678910",
                Name = "Alguien",
                Lastname = "Mas",
                Password = "63640264849a87c90356129d99ea165e37aa5fabc1fea46906df1a7ca50db492",
                RoleId = 2
            },
            new User()
            {
                Cuit = "63466345555",
                Name = "Agustin",
                Lastname = "Binci",
                Password = "c59ff102669ca87df56502f325b0797220604576f014ef865273fb5d8d0d1016",
                RoleId = 2
            },
            new User()
            {
                Cuit = "75543212233",
                Name = "Guido",
                Lastname = "Armando",
                Password = "5260918786fc37fff92a1530a488be4a1daf0a75470f02c2d4d443fe0ba5f9f2",
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

        public override IEnumerable<User> GetUserByRoleId(int RoleId)
        {
            IEnumerable<User> Users = _users.Where(User => User.RoleId.Equals(RoleId)).ToList();

            if (Users != null)
                return Users;

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
