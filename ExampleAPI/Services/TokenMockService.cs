using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class TokenMockService : ITokenService
    {
        //Simulación de armado de token
        public String GetToken(String UserId)
        {
            if (String.IsNullOrEmpty(UserId)) throw new NullReferenceException();

            String Separator = "_";
            String RandomChars = "gd4g42sdgds0";
            String Token = UserId + Separator + RandomChars;

            return Token;
        }

        //Simulación de armado de token
        public String GetUserId(String Token)
        {
            if (String.IsNullOrEmpty(Token)) throw new NullReferenceException();

            String[] Tokens = Token.Split('_');

            if (Tokens.Count().Equals(0)) throw new KeyNotFoundException();

            return Tokens[0];
        }
    }
}