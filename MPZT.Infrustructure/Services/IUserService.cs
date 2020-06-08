using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Services
{
    public interface IUserService
    {
        bool ValidateUser(string userName, string password);
        UserDto GetUser(string userName);
        IList<RoleDto> GetRolesForUser(string userName);
        UserDto GetUserByEmail(string email);

        /// <summary>
        /// Inserts instance of User class into database and set its role as "User" by default.
        /// </summary>
        /// <param name="user">The instance of User class.</param>
        /// <returns>Id property of the new user.</returns>
        int InsertUser(UserDto user);

        /// <summary>
        /// Gets the value of Id of Office by Id of the User.
        /// </summary>
        /// <param name="userId">The value of Id of instance of User class.</param>
        /// <returns>The value of Id of specific Office</returns>
        int GetOfficeId(int userId);

    }
}
