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

    }
}
