﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEncryptionService
    {
        String Encrypt(String Text);
    }
}
