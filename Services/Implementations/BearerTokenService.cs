using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class BearerTokenService : ITokenService
    {
        private static char _separator = ':';

        public string GetCuitFromUnencodedToken(string UnencodedToken)
        {
            String Cuit = UnencodedToken.Substring(0, UnencodedToken.IndexOf(_separator));

            return Cuit;
        }

        public string GetEncodedToken(string Cuit, string Password)
        {
            IList<byte> Bytes = new List<byte>();

            foreach (char Char in (Cuit + _separator + Password).ToCharArray())
            {
                Bytes.Add(Convert.ToByte(Char));
            }

            String Token = Convert.ToBase64String(Bytes.ToArray());

            return Token;
        }

        public string GetPasswordFromUnencodedToken(string UnencodedToken)
        {
            String Password = UnencodedToken.Substring(UnencodedToken.IndexOf(_separator) + 1);

            return Password;
        }

        public string GetUnencodedToken(string Token)
        {
            String UnencodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(Token));

            return UnencodedToken;
        }
    }
}
