using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class ExpirationStateMemoryDao : ExpirationStateDao
    {
        private static IList<ExpirationState> _expirationStates = new List<ExpirationState>()
        {
            new ExpirationState() { ExpirationStateId = 1, Description = "Vigente" },
            new ExpirationState() { ExpirationStateId = 2, Description = "A punto de vencer" },
            new ExpirationState() { ExpirationStateId = 3, Description = "Vencida" }
        };

        public override void Create(ExpirationState Entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ExpirationState> GetAll()
        {
            return _expirationStates;
        }

        public override ExpirationState GetById(int ExpirationStateId)
        {
            ExpirationState ExpirationState = _expirationStates.FirstOrDefault(EState => EState.ExpirationStateId.Equals(ExpirationStateId));

            if (ExpirationState == null)
                throw new EntityNotFoundException();

            return ExpirationState;
        }

        public override void Update(ExpirationState Entity)
        {
            throw new NotImplementedException();
        }
    }
}
