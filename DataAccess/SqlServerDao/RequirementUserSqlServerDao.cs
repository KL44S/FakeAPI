using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.EntityModel;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class RequirementUserSqlServerDao : RequirementUserDao
    {
        public override void Create(RequirementUser RequirementUser)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement EntityRequirement = ObrasEntities.Requirement.FirstOrDefault(Requirement =>
                                                            Requirement.requirementNumber.Equals(RequirementUser.RequirementNumber));

                EntityModel.User EntityUser = ObrasEntities.User.FirstOrDefault(User => User.cuit.Equals(RequirementUser.Cuit));

                EntityRequirement.User.Add(EntityUser);
                ObrasEntities.SaveChanges();
            }
        }

        private RequirementUser CreateAndGetRequirementUser(EntityModel.User User, EntityModel.Requirement Requirement)
        {
            RequirementUser RequirementUser = new RequirementUser();
            RequirementUser.Cuit = User.cuit;
            RequirementUser.RequirementNumber = Requirement.requirementNumber;

            return RequirementUser;
        }

        private void FillRequirementUsers(IList<RequirementUser> RequirementUsers, IEnumerable<EntityModel.Requirement> Requirements)
        {
            if (Requirements != null)
            {
                foreach (EntityModel.Requirement Requirement in Requirements)
                {
                    foreach (EntityModel.User User in Requirement.User)
                    {
                        RequirementUser RequirementUser = this.CreateAndGetRequirementUser(User, Requirement);
                        RequirementUsers.Add(RequirementUser);
                    }
                }
            }
        }

        private void FillRequirementUsers(IList<RequirementUser> RequirementUsers, IEnumerable<EntityModel.User> Users)
        {
            if (Users != null)
            {
                foreach (EntityModel.User User in Users)
                {
                    foreach (EntityModel.Requirement Requirement in User.Requirement)
                    {
                        RequirementUser RequirementUser = this.CreateAndGetRequirementUser(User, Requirement);
                        RequirementUsers.Add(RequirementUser);
                    }
                }
            }
        }

        public override IEnumerable<RequirementUser> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IList<RequirementUser> RequirementUsers = new List<RequirementUser>();
                IEnumerable<EntityModel.Requirement> Requirements = ObrasEntities.Requirement.ToList();

                this.FillRequirementUsers(RequirementUsers, Requirements);

                return RequirementUsers;
            }
        }

        public override IEnumerable<RequirementUser> GetAllByCuit(string Cuit)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IList<RequirementUser> RequirementUsers = new List<RequirementUser>();
                IEnumerable<EntityModel.User> Users = ObrasEntities.User.Where(EntityUser => EntityUser.cuit.Equals(Cuit));

                this.FillRequirementUsers(RequirementUsers, Users);

                return RequirementUsers;
            }
        }

        public override IEnumerable<RequirementUser> GetAllByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IList<RequirementUser> RequirementUsers = new List<RequirementUser>();
                IEnumerable<EntityModel.Requirement> Requirements = ObrasEntities.Requirement.Where(EntityRequirement => 
                                                                        EntityRequirement.requirementNumber.Equals(RequirementNumber));

                this.FillRequirementUsers(RequirementUsers, Requirements);

                return RequirementUsers;
            }
        }

        public override RequirementUser GetByCuitAndRequirementNumber(string Cuit, int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.User EntityUser = ObrasEntities.User.FirstOrDefault(User => User.cuit.Equals(Cuit)
                                                                                && (User.Requirement.FirstOrDefault(Requirement =>
                                                                                    Requirement.requirementNumber.Equals(RequirementNumber))) != null);

                if (EntityUser == null)
                    throw new EntityNotFoundException();

                RequirementUser RequirementUser = new RequirementUser();
                RequirementUser.Cuit = Cuit;
                RequirementUser.RequirementNumber = RequirementNumber;

                return RequirementUser;
            }
        }

        public override void Update(RequirementUser RequirementUser)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement Requirement = ObrasEntities.Requirement.FirstOrDefault(Req => Req.requirementNumber.Equals(RequirementUser.RequirementNumber));
                EntityModel.User CurrentUser = ObrasEntities.User.FirstOrDefault(User => User.cuit.Equals(RequirementUser.Cuit));
                EntityModel.User OldUser = ObrasEntities.User.FirstOrDefault(User => User.roleId.Equals(CurrentUser.roleId) && (User.Requirement.FirstOrDefault(Req =>
                                                                                    Req.requirementNumber.Equals(Requirement.requirementNumber))) != null);

                OldUser.Requirement.Remove(Requirement);
                Requirement.User.Remove(OldUser);

                CurrentUser.Requirement.Add(Requirement);
                Requirement.User.Add(CurrentUser);

                ObrasEntities.SaveChanges();
            }
        }

        public override void DeleteAllByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement Requirement = ObrasEntities.Requirement.FirstOrDefault(Req => Req.requirementNumber.Equals(RequirementNumber));
                Requirement.User.Clear();

                IEnumerable<EntityModel.User> Users = ObrasEntities.User.Where(User => User.Requirement.FirstOrDefault(Req =>
                                                                                    Req.requirementNumber.Equals(RequirementNumber)) != null);

                foreach (EntityModel.User User in Users)
                {
                    User.Requirement.Remove(Requirement);
                }

                ObrasEntities.SaveChanges();
            }
        }
    }
}
