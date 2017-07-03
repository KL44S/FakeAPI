using DataAccess.SqlServerDao.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.Mapping;

namespace DataAccess.SqlServerDao
{
    public class UserSqlServerDao : UserDao
    {
        private ObrasEntities _obrasEntities;
        
        public UserSqlServerDao()
        {
            this._obrasEntities = new ObrasEntities();
        }

        public override void Create(Model.User User)
        {
            EntityModel.User UserEntity = UserMapping.MapModelUser(User);

            this._obrasEntities.User.Add(UserEntity);
            this._obrasEntities.SaveChanges();
        }

        public override IEnumerable<Model.User> GetAll()
        {
            IEnumerable<Model.User> Users = UserMapping.UnMapEntityUsers(this._obrasEntities.User.ToList());

            return Users;
        }

        public override Model.User GetUserByCuit(string Cuit)
        {
            EntityModel.User EntityUser = this._obrasEntities.User.FirstOrDefault(User => User.cuit.Equals(Cuit));

            if (EntityUser == null)
            {
                //TODO: lanzar excepcion
            }

            return UserMapping.UnMapEntityUser(EntityUser);
        }

        public override Model.User GetUserByCuitAndPassword(string Cuit, string Password)
        {
            EntityModel.User EntityUser = this._obrasEntities.User.FirstOrDefault(User => User.cuit.Equals(Cuit) && User.password.Equals(Password));

            if (EntityUser == null)
            {
                //TODO: lanzar excepcion
            }

            return UserMapping.UnMapEntityUser(EntityUser);
        }

        public override void Update(Model.User User)
        {
            EntityModel.User EntityUser = this._obrasEntities.User.FirstOrDefault(AnUser => AnUser.cuit.Equals(User.Cuit));

            UserMapping.MapModelUser(User, EntityUser);

            this._obrasEntities.SaveChanges();
        }
    }
}
