using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class UserMapping : Mapping<Model.User, EntityModel.User>
    {
        internal override void UnMapEntity(EntityModel.User EntityUser, Model.User User)
        {
            User.Cuit = EntityUser.cuit;
            User.RoleId = EntityUser.roleId;
            User.Name = EntityUser.name;
            User.Lastname = EntityUser.lastname;
        }

        internal override void MapModel(Model.User User, EntityModel.User EntityModel)
        {
            EntityModel.User EntityUser = new EntityModel.User();
            EntityUser.cuit = User.Cuit;
            EntityUser.roleId = User.RoleId;
            EntityUser.name = User.Name;
            EntityUser.lastname = User.Lastname;
        }

        protected override Model.User CreateModel()
        {
            return new Model.User();
        }

        protected override EntityModel.User CreateEntity()
        {
            return new EntityModel.User();
        }

    }
}
