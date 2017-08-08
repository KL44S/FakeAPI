using DataAccess.AbstractDao;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MemoryDao
{
    public class ParameterMemoryDao : ParameterDao
    {
        private static IDictionary<String, String> _parameters = new Dictionary<String, String>()
        {
            { "firstSheetStateId", "1" },
            { "finalSheetStateId", "3" },
            { "maxItemDescriptionLength", "99" },
            { "minItemDescriptionLength", "1" },
            { "maxUnitOfMeasurementLength", "50" },
            { "minUnitOfMeasurementLength", "1" },
            { "maxProviderDescriptionLength", "99" },
            { "minProviderDescriptionLength", "1" },
            { "maxSubItemDescriptionLength", "99" },
            { "minSubItemDescriptionLength", "1" },
            { "maxCertificationDays", "60" },
            { "minCertificationDays", "15" },
            { "maxPurchaseOrderExcercise", "2050" },
            { "minPurchaseOrderExcercise", "2015" },
            { "maxPurchaseOrder", "9999999" },
            { "minPurchaseOrder", "1" },
            { "maxRequirementNumber", "9999999" },
            { "minRequirementNumber", "1" },
            { "maxTotalQuantity", "999999" },
            { "minTotalQuantity", "1" },
            { "minUnitPrice", "1" },
            { "maxUnitPrice", "999999" },
            { "WarningDaysBeforeExpiration", "5" }
        };

        public override String GetParameterById(String Id)
        {
            if (!_parameters.ContainsKey(Id))
                throw new EntityNotFoundException();

            String Value = _parameters[Id];

            return Value;
        }
    }
}
