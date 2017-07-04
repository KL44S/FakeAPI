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
    public class SubItemMemoryDao : SubItemDao
    {
        private static IList<SubItem> _subItems = new List<SubItem>()
        {
            new SubItem()
            {
                ItemNumber = 1,
                SubItemNumber = 1,
                RequirementNumber = 1556,
                Sis = "AA",
                Description = "Trabajos preliminares",
                UnitPrice = 4365.44f,
                UnitOfMeasurement = "UN",
                TotalQuantity = 34       
            },
            new SubItem()
            {
                ItemNumber = 1,
                SubItemNumber = 2,
                RequirementNumber = 1556,
                Sis = "AA",
                Description = "Documentación gráfica, proyecto ejecutivo. Presentación ante orgnaismos oficiales",
                UnitPrice = 4365.44f,
                UnitOfMeasurement = "UN",
                TotalQuantity = 33
            },
            new SubItem()
            {
                ItemNumber = 1,
                SubItemNumber = 3,
                RequirementNumber = 1556,
                Sis = "AA",
                Description = "Cartel de obra",
                UnitPrice = 43.44f,
                UnitOfMeasurement = "UN",
                TotalQuantity = 1
            },
            new SubItem()
            {
                ItemNumber = 2,
                SubItemNumber = 1,
                RequirementNumber = 1556,
                Sis = "AA",
                Description = "Limpieza de obra y obrero",
                UnitPrice = 4.44f,
                UnitOfMeasurement = "HORAS",
                TotalQuantity = 2
            },
            new SubItem()
            {
                ItemNumber = 2,
                SubItemNumber = 2,
                RequirementNumber = 1556,
                Sis = "AA",
                Description = "Obrador, depósitos, sanitarios",
                UnitPrice = 43.44f,
                UnitOfMeasurement = "UN",
                TotalQuantity = 22.3f
            },
            new SubItem()
            {
                ItemNumber = 3,
                SubItemNumber = 1,
                RequirementNumber = 1556,
                Sis = "AA",
                Description = "Cerco de seguridad, pasarelas, señalización",
                UnitPrice = 43.0f,
                UnitOfMeasurement = "METROS",
                TotalQuantity = 13
            }
        };

        public override void Create(SubItem SubItem)
        {
            _subItems.Add(SubItem);
        }

        public override IEnumerable<SubItem> GetAll()
        {
            return _subItems;
        }

        public override IEnumerable<SubItem> GetAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            IEnumerable<SubItem> SubItems = _subItems.Where(SubItem => SubItem.RequirementNumber.Equals(RequirementNumber) &&
                                                                             SubItem.ItemNumber.Equals(ItemNumber));

            if (SubItems != null && SubItems.Count() > 0)
                return SubItems;

            throw new EntityNotFoundException();
        }

        public override void Update(SubItem SubItem)
        {
            throw new NotImplementedException();
        }
    }
}
