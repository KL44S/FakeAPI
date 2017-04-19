using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public interface ITokenService
    {
        String GetToken(String UserId);
        String GetUserId(String Token);
    }
}