using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class UserMapping
    {
        internal static void UnMapEntityUser(EntityModel.User EntityUser, Model.User User)
        {
            User.Cuit = EntityUser.cuit;
            User.RoleId = EntityUser.roleId;
            User.Name = EntityUser.name;
            User.Lastname = EntityUser.lastname;
        }

        internal static Model.User UnMapEntityUser(EntityModel.User EntityUser)
        {
            Model.User User = new Model.User();

            UnMapEntityUser(EntityUser, User);

            return User;
        }

        internal static IEnumerable<Model.User> UnMapEntityUsers(IEnumerable<EntityModel.User> EntityUsers)
        {
            IList<Model.User> Users = new List<Model.User>();

            foreach (EntityModel.User EntityUser in EntityUsers)
            {
                Users.Add(UnMapEntityUser(EntityUser));
            }

            return Users;
        }

        internal static void MapModelUser(Model.User User, EntityModel.User EntityModel)
        {
            EntityModel.User EntityUser = new EntityModel.User();
            EntityUser.cuit = User.Cuit;
            EntityUser.roleId = User.RoleId;
            EntityUser.name = User.Name;
            EntityUser.lastname = User.Lastname;
        }

        internal static EntityModel.User MapModelUser(Model.User User)
        {
            EntityModel.User EntityUser = new EntityModel.User();

            MapModelUser(User, EntityUser);

            return EntityUser;
        }

        internal static IEnumerable<EntityModel.User> MapModelUsers(IEnumerable<Model.User> Users)
        {
            IList<EntityModel.User> EntityUsers = new List<EntityModel.User>();

            foreach (Model.User ModelUser in Users)
            {
                EntityUsers.Add(MapModelUser(ModelUser));
            }

            return EntityUsers;
        }
    }
}
