using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;
using DataAccess.Factories;
using Exceptions;

namespace Services.Implementations
{
    public class RequirementUserService : IRequirementUserService
    {
        private RequirementUserDao _requirementUserDao;
        private UserDao _userDao;

        public RequirementUserService()
        {
            this._requirementUserDao = (new RequirementUserDaoFactory()).GetDaoInstance();
            this._userDao = (new UserDaoFactory()).GetDaoInstance();
        }

        public IEnumerable<User> GetUsersFromRequirementNumber(int RequirementNumber)
        {
            if (RequirementNumber < 0)
                throw new ArgumentException();

            IList<User> Users = new List<User>(); 
            IEnumerable<RequirementUser> RequirementUsers = this._requirementUserDao.GetAllByRequirementNumber(RequirementNumber);

            foreach (RequirementUser RequirementUser in RequirementUsers)
            {
                User User = this._userDao.GetUserByCuit(RequirementUser.Cuit);
                Users.Add(User);
            }

            return Users;
        }

        private void Save(RequirementUser RequirementUser)
        {
            IEnumerable<RequirementUser> RequirementUsers = this._requirementUserDao.GetAllByRequirementNumber(RequirementUser.RequirementNumber);
            User User = this._userDao.GetUserByCuit(RequirementUser.Cuit);
            Boolean Found = false;
            int Index = 0;

            while (Index < RequirementUsers.Count() && !Found)
            {
                RequirementUser ExistingRequirementUser = RequirementUsers.ElementAt(Index);
                User CurrentUser = this._userDao.GetUserByCuit(ExistingRequirementUser.Cuit);

                if (CurrentUser.RoleId.Equals(User.RoleId))
                {
                    Found = true;
                    ExistingRequirementUser.Cuit = User.Cuit;
                    this._requirementUserDao.Update(ExistingRequirementUser);
                }

                Index++;
            }

            if (!Found)
            {
                this._requirementUserDao.Create(RequirementUser);
            }
        }

        public void SaveRequirementUser(RequirementUser RequirementUser)
        {
            if (RequirementUser == null)
                throw new ArgumentException();

            IList<User> Users = new List<User>();
            try
            {
                RequirementUser ExistinRequirementUser = this._requirementUserDao.GetByCuitAndRequirementNumber(RequirementUser.Cuit,
                                                                                           RequirementUser.RequirementNumber);

                if (ExistinRequirementUser != null)
                {
                    return;
                }

                this.Save(RequirementUser);
            }
            catch (EntityNotFoundException)
            {
                this.Save(RequirementUser);
            }
        }

        public bool DoesRequirementHaveTheUser(int RequirementNumber, string Cuit)
        {
            if (RequirementNumber <= 0 || String.IsNullOrEmpty(Cuit))
                throw new ArgumentException();

            try
            {
                RequirementUser ExistinRequirementUser = this._requirementUserDao.GetByCuitAndRequirementNumber(Cuit, RequirementNumber);
                return true;
            }
            catch (EntityNotFoundException)
            {
                return false;
            }
        }

        public void DeleteByRequirementNumber(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentException();

            this._requirementUserDao.DeleteAllByRequirementNumber(RequirementNumber);
        }
    }
}
