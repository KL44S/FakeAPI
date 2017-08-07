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
    public class MessageSqlServerDao : MessageDao
    {
        public override void Create(string Entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public override string GetById(string Id)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                Message FoundMessage = ObrasEntities.Message.FirstOrDefault(Message => Message.id.Equals(Id));

                if (FoundMessage == null)
                    throw new EntityNotFoundException();

                return FoundMessage.message1;
            }
        }

        public override void Update(string Entity)
        {
            throw new NotImplementedException();
        }
    }
}
