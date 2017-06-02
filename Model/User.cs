using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //Clase cross a ambos proyectos. En realidad cada proyecto debería tener su modelo
    public class User
    {
        public String cuit { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public int idRol { get; set; }
        public IList<int> obras { get; set; }
    }
}
