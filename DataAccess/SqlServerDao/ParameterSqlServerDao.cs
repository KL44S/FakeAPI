using DataAccess.AbstractDao;
using DataAccess.SqlServerDao.EntityModel;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServerDao
{
    public class ParameterSqlServerDao : ParameterDao
    {
        public override string GetParameterById(string Id)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                Parameter FoundParameter = ObrasEntities.Parameter.FirstOrDefault(Parameter => Parameter.id.Equals(Id));

                if (FoundParameter == null)
                    throw new EntityNotFoundException();

                return FoundParameter.value;
            }
        }
    }
}
