using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITokenService
    {
        String GetEncodedToken(String Cuit, String Password);
        String GetUnencodedToken(String Token);
        String GetCuitFromUnencodedToken(String UnencodedToken);
        String GetPasswordFromUnencodedToken(String UnencodedToken);
    }
}
