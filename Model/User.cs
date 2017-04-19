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
        public String UserId { get; set; }
        public String Password { get; set; }
        public String Token { get; set; }
    }
}
