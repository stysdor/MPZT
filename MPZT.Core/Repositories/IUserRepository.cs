using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of User class.
    /// </summary>
    public interface IUserRepository 
    {
        /// <summary>
        /// Validates User credentials.
        /// </summary>
        /// <param name="userName">The userName string to ckeck</param>
        /// <param name="password">The password string to check.</param>
        /// <returns>True if user with specific <paramref name="userName"/> and <paramref name="password"/> exists in the database, or false otherwise.</returns>
        bool ValidateUser(string userName, string password);

        /// <summary>
        /// Gets instance of User class.
        /// </summary>
        /// <param name="userName">The userName string</param>
        /// <returns>Instance of User class with specific value of UserName property.</returns>
        User GetUser(string userName);

        /// <summary>
        /// Gets IList of instances of Role class .
        /// </summary>
        /// <param name="userName">The userName string to find</param>
        /// <returns>IList of instances of Role class for instance of User class with specific value of UserName property.</returns>
        IList<Role> GetRolesForUser(string userName);

        /// <summary>
        /// Gets the UserName property of instance of User class.
        /// </summary>
        /// <param name="email">The email string</param>
        /// <returns>The UserName value of instance of User class with specific value of Email property.</returns>
        string GetUserNameByEmail(string email);

        /// <summary>
        /// Inserts instance of User class into database.
        /// </summary>
        /// <param name="item">The instance of User class.</param>
        /// <returns>The Id of the new User in database.</returns>
        int InsertUser(User item);

        /// <summary>
        /// Sets role to instance of User class.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <param name="role">The name of role to set</param>
        /// <returns>True if setting succeeds, or false otherwise.</returns>
        bool SetRoleForUser(int userId, string role);

        /// <summary>
        /// Gets an Id value of instance of Office class by the Id of OfficeMember
        /// </summary>
        /// <param name="userId">The value of Id property of OfficeMember (Base class: User)</param>
        /// <returns>The Id of instance of Office class.</returns>
        int GetOfficeId(int userId);
    }
}
