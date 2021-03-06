﻿using DataAccess.AbstractDao;
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
            { "existingRequirement", "Ya existe una obra con ese número" },
            { "emptyField", "Este campo no puede estar vacío" },
            { "numberRangeField", "Este campo debe estar entre " },
            { "textRangeField", "Este campo debe tener entre " },
            { "andRangeField", " y " },
            { "textRangeFieldChars", " caracteres" },
            { "PartialQuantityExcededParameter", "Este valor excede la cantidad total del sub-item" },
            { "PartialPercentExcededParameter",  "El porcentaje no puede ser mayor a 100" },
            { "PartialInputsNotMatchedParameter", "El porcentaje no coincide con la cantidad ingresada" }
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
