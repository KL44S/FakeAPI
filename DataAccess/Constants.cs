using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Constants
    {
        public enum Techs { SqlServer, Memory };
        internal static Techs CurrentTech = Techs.Memory;
    }
}
