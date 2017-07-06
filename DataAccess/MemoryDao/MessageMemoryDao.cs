using DataAccess.AbstractDao;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MemoryDao
{
    public class MessageMemoryDao : MessageDao
    {
        private static IDictionary<String, String> _messages = new Dictionary<String, String>()
        {
            { "existingRequirement", "Ya existe una obra con ese número" }
        };

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
            if (_messages.ContainsKey(Id))
            {
                return _messages[Id];
            }

            throw new EntityNotFoundException();
        }

        public override void Update(string Entity)
        {
            throw new NotImplementedException();
        }
    }
}
