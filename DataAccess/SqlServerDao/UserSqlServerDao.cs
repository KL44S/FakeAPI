using DataAccess.SqlServerDao.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.Mapping;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class UserSqlServerDao : UserDao
    {
        private UserMapping _userMapping;

        public UserSqlServerDao()
        {
            this._userMapping = new UserMapping();
        }

        public override void Create(Model.User User)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.User UserEntity = this._userMapping.MapModel(User);

                ObrasEntities.User.Add(UserEntity);
                ObrasEntities.SaveChanges();
            }
        }

        public override IEnumerable<Model.User> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<Model.User> Users = this._userMapping.UnMapEntities(ObrasEntities.User.ToList());

                return Users;
            }
        }

        public override Model.User GetUserByCuit(string Cuit)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.User EntityUser = ObrasEntities.User.FirstOrDefault(User => User.cuit.Equals(Cuit));

                if (EntityUser == null)
                {
                    throw new EntityNotFoundException();
                }

                return this._userMapping.UnMapEntity(EntityUser);
            }
        }

        public override Model.User GetUserByCuitAndPassword(string Cuit, string Password)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.User EntityUser = ObrasEntities.User.FirstOrDefault(User => User.cuit.Equals(Cuit) && User.password.Equals(Password));

                if (EntityUser == null)
                {
                    throw new EntityNotFoundException();
                }

                return this._userMapping.UnMapEntity(EntityUser);
            }
        }

        public override IEnumerable<Model.User> GetUserByRoleId(int RoleId)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.User> EntityUsers = ObrasEntities.User.Where(User => User.roleId.Equals(RoleId));

                if (EntityUsers == null)
                {
                    throw new EntityNotFoundException();
                }

                return this._userMapping.UnMapEntities(EntityUsers);
            }
        }

        public override void Update(Model.User User)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.User EntityUser = ObrasEntities.User.FirstOrDefault(AnUser => AnUser.cuit.Equals(User.Cuit));

                this._userMapping.MapModel(User, EntityUser);

                ObrasEntities.SaveChanges();
            }

        }
    }
}
