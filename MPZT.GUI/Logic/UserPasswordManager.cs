using MPZT.GUI.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MPZT.GUI.Logic
{
    public class UserPasswordManager : IUserPasswordManager
    {

        private MD5 md5Hash;

        public UserPasswordManager()
        {
            md5Hash = MD5.Create();
        }

        public string GetHash(string password)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool VerifyHash(string password, string passwordHash)
        {
            string hashOfInput = GetHash(password);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, passwordHash))
                return true;
            
            else
                return false;
        }


        public void Dispose()
        {
            md5Hash.Dispose();
        }
    }
}