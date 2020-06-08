using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.GUI.Logic.Interface
{
    /// <summary>
    /// Interface for hashing passwords.
    /// </summary>
    interface IUserPasswordManager: IDisposable
    {
        /// <summary>
        /// Gets hashed password 
        /// </summary>
        /// <param name="password">The password string to hash</param>
        /// <returns>The string with the encrypted password.</returns>
        string GetHash(string password);

        /// <summary>
        /// Checks if the password matches the encrypted password.
        /// </summary>
        /// <param name="password">The string with password</param>
        /// <param name="passwordHash">The sring with the encrypted password</param>
        /// <returns>True if the encrypted password and password match, or false otherwise.</returns>
        bool VerifyHash(string password, string passwordHash);
    }
}
