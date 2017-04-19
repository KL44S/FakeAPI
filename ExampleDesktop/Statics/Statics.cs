using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDesktop.Statics
{
    public static class Statics
    {
        public static String Token { get; set; }
        public static String ApiPath = "http://localhost:51249/api/";
        public static String AuthenticationHeader = "Authentication";
    }
}
