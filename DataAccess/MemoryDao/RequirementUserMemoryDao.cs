using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class RequirementUserMemoryDao : RequirementUserDao
    {
        private static IList<RequirementUser> _requirementUsers = new List<RequirementUser>()
        {
            new RequirementUser()
            {
                 RequirementNumber = 1556,
                 Cuit = "12345678"
            },
            new RequirementUser()
            {
                 RequirementNumber = 1556,
                 Cuit = "12345678910"
            },
            new RequirementUser()
            {
                 RequirementNumber = 1556,
                 Cuit = "75543212233"
            },
            new RequirementUser()
            {
                 RequirementNumber = 1557,
                 Cuit = "63466345555"
            },
            new RequirementUser()
            {
                 RequirementNumber = 1557,
                 Cuit = "12345678"
            },
            new RequirementUser()
            {
                 RequirementNumber = 1558,
                 Cuit = "12345678910"
            },
            new RequirementUser()
            {
                 RequirementNumber = 1558,
                 Cuit = "12345678"
            }
        };

        public override void Create(RequirementUser RequirementUser)
        {
            _requirementUsers.Add(RequirementUser);
        }

        public override IEnumerable<RequirementUser> GetAll()
        {
            return _requirementUsers;
        }

        public override IEnumerable<RequirementUser> GetAllByCuit(string Cuit)
        {
            IEnumerable<RequirementUser> RequirementUsers = _requirementUsers.Where(RequirementUser => RequirementUser.Cuit.Equals(Cuit)).ToList();

            if (RequirementUsers != null)
                return RequirementUsers;

            throw new EntityNotFoundException();
        }

        public override IEnumerable<RequirementUser> GetAllByRequirementNumber(int RequirementNumber)
        {
            IEnumerable<RequirementUser> RequirementUsers = _requirementUsers.Where(RequirementUser => 
                                                                            RequirementUser.RequirementNumber.Equals(RequirementNumber)).ToList();

            if (RequirementUsers != null)
                return RequirementUsers;

            throw new EntityNotFoundException();
        }

        public override RequirementUser GetByCuitAndRequirementNumber(string Cuit, int RequirementNumber)
        {
            RequirementUser FoundRequirementUser = _requirementUsers.FirstOrDefault(RequirementUser => RequirementUser.Cuit.Equals(Cuit)
                                                                            && RequirementUser.RequirementNumber.Equals(RequirementNumber));

            if (FoundRequirementUser != null)
                return FoundRequirementUser;

            throw new EntityNotFoundException();
        }

        public override void Update(RequirementUser RequirementUser)
        {
            //Nada para hacer
        }
    }
}
