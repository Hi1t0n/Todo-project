using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;

namespace UserService.Infrastructure.Helpers;

public class HashPassword
{
    public static string PasswordHash(string password)
    {
        using(SHA256 sha256 = SHA256.Create())
        {
            if (password.Length is 0) { throw new Exception("Пароль не может быть пустым"); }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
