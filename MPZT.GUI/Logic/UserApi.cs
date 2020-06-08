using AutoMapper;
using MPZT.GUI.DataAccess;
using MPZT.GUI.Logic.Interface;
using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Logic
{
    /// <summary>
    /// Class for operations with user account.
    /// </summary>
    public class UserApi
    {
        private IUserPasswordManager _userPasswordManager;
        /// <summary>
        /// Constructor of UserApi class. It creates an instance of UserPasswordManager class. 
        /// </summary>
        public UserApi()
        {
            _userPasswordManager = new UserPasswordManager();
        }

        /// <summary>
        /// Gets instance of UserDto class with specific UserName property by ApiClient class and convert it into User class.
        /// </summary>
        /// <param name="username">The value of UserName property.</param>
        /// <returns>Instance of MPZT.GUI.DataAccess.User class with specific UserName property.</returns>
        public User GetUser(string username)
        {
            var userDto = new ApiClient().GetData<UserDto>($"api/account/GetUser/{username}");
            if (!(userDto == null))
            {
                var user = new User()
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    Id = userDto.Id,
                    LastName = userDto.LastName,
                };
                user.Roles = GetRolesForUser(username);
                return user;
            }
            else return null;      
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
            string hashedPassword = _userPasswordManager.GetHash(password);
            UserDto user = new UserDto()
            {
                UserName = username,
                Password = hashedPassword
            };
            bool isValidate = new ApiClient().PostData<UserDto, bool>("api/account/PostValidation", user);
            return isValidate;
        }

        public string GetUserByEmail(string email)
        {
            var user = new ApiClient().GetData<UserDto>($"api/account/GetUserByEmail/{email}/");
            if (!(user == null))
                return user.UserName;
            else return null;
        }

        public int GetOfficeIdByUserId(int userId)
        {
            int id = new ApiClient().GetData($"api/account/GetOfficeId/{userId}");
            return id;
        }
        
    }
}