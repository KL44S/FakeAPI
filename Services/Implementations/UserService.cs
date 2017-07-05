using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;
using DataAccess.Factories;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private UserDao _userDao;
        private RequirementUserDao _requirementUserDao;

        public UserService()
        {
            UserDaoFactory UserDaoFactory = new UserDaoFactory();
            this._userDao = UserDaoFactory.GetDaoInstance();

            RequirementUserDaoFactory RequirementUserDaoFactory = new RequirementUserDaoFactory();
            this._requirementUserDao = RequirementUserDaoFactory.GetDaoInstance();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAll();
        }

        public User GetUserByCuit(string Cuit)
        {
            if (String.IsNullOrEmpty(Cuit))
                throw new ArgumentNullException();

            User User = _userDao.GetUserByCuit(Cuit);

            return User;
        }

        public User GetUserByCuitAndPassword(string Cuit, string Password)
        {
            if (String.IsNullOrEmpty(Cuit) || String.IsNullOrEmpty(Password))
                throw new ArgumentNullException();

            User User = _userDao.GetUserByCuitAndPassword(Cuit, Password);

            return User;
        }

        private IEnumerable<User> GetAllUsersByCuits(IEnumerable<RequirementUser> RequirementUsers)
        {
            IList<User> Users = new List<User>();

            foreach (RequirementUser RequirementUser in RequirementUsers)
            {
                User User = this.GetUserByCuit(RequirementUser.Cuit);
                Users.Add(User);
            }

            return Users;
        }

        public IEnumerable<User> GetUsersByRequirementNumber(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentNullException();

            IEnumerable<RequirementUser> RequirementUsers = this._requirementUserDao.GetAllByRequirementNumber(RequirementNumber);
            IEnumerable<User> Users = this.GetAllUsersByCuits(RequirementUsers);

            return Users;
        }

        public IEnumerable<User> GetUsersByRoleId(int RoleId)
        {
            if (RoleId <= 0)
                throw new ArgumentNullException();

            IEnumerable<User> Users = this._userDao.GetUserByRoleId(RoleId);

            return Users;
        }

        private IEnumerable<User> GetAllUsersByCuits(IEnumerable<RequirementUser> RequirementUsers, IEnumerable<User> Users)
        {
            IList<User> FilteredUsers = new List<User>();
            Boolean UserFound = false;
            int index = 0;

            foreach (RequirementUser RequirementUser in RequirementUsers)
            {
                UserFound = false;
                index = 0;

                while (!UserFound && index < Users.Count())
                {
                    User User = Users.ElementAt(index);

                    if (User.Cuit.Equals(RequirementUser.Cuit))
                    {
                        UserFound = true;
                        FilteredUsers.Add(User);
                    }

                    index ++;
                }
            }

            return FilteredUsers;
        }

        public IEnumerable<User> GetUsersByRoleIdAndRequirementNumber(int RoleId, int RequirementNumber)
        {
            if (RoleId <= 0 || RequirementNumber <= 0)
                throw new ArgumentNullException();

            IEnumerable<User> Users = this._userDao.GetUserByRoleId(RoleId);
            IEnumerable<RequirementUser> RequirementUsers = this._requirementUserDao.GetAllByRequirementNumber(RequirementNumber);
            Users = this.GetAllUsersByCuits(RequirementUsers, Users);

            return Users;
        }
    }
}
