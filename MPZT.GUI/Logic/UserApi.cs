using AutoMapper;
using MPZT.GUI.DataAccess;
using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Logic
{
    public class UserApi
    {
        public User GetUser(string username)
        {
            var userDto = new ApiClient().GetData<UserDto>($"api/account/GetUser/{username}");
            var user = new User()
            {
                UserName = userDto.UserName,
                Email =userDto.Email,
                FirstName = userDto.FirstName,
                Id = userDto.Id,
                LastName = userDto.LastName,
            };
            user.Roles = GetRolesForUser(username);
            return user;
        }

        public List<Role> GetRolesForUser(string username)
        {
            var rolesDto = new ApiClient().GetData<List<RoleDto>>($"api/account/GetRolesForUser/{username}");
            var roles = new List<Role>();
            foreach (var role in rolesDto)
            {
                roles.Add(new Role()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                });
            }
            return roles;
        }

        public bool GetValidation(string username, string password)
        {
            UserDto user = new UserDto()
            {
                UserName = username,
                Password = password
            };
            bool isValidate = new ApiClient().PostData<UserDto, bool>("api/account/PostValidation", user);
            return isValidate;
        }
        
    }
}