using ExampleAPI.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class UserMappingService : MappingService<User, UserViewModel>
    {
        public override User MapViewModel(UserViewModel UserViewModel)
        {
            User User = new User();
            User.Cuit = UserViewModel.cuit;
            User.Name = UserViewModel.name;
            User.Lastname = UserViewModel.lastname;
            User.RoleId = UserViewModel.idRol;

            return User;
        }

        public override UserViewModel UnMapEntity(User User)
        {
            UserViewModel UserViewModel = new UserViewModel();
            UserViewModel.cuit = User.Cuit;
            UserViewModel.name = User.Name;
            UserViewModel.lastname = User.Lastname;
            UserViewModel.idRol = User.RoleId;

            return UserViewModel;
        }
    }
}