﻿using AutoMapper;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Services
{
    public class UserService: IUserService
    {
        private IMapper _mapper;
        private IUserRepository _userRepository;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = new UserRepository();
        }

        public bool ValidateUser(string userName, string password)
        {
            return _userRepository.ValidateUser(userName, password);
        }
        public UserDto GetUser(string userName)
        {
            return _mapper.Map<UserDto>(_userRepository.GetUser(userName));
        }
        public IList<RoleDto> GetRolesForUser(string userName)
        {
            return _mapper.Map<List<RoleDto>>(_userRepository.GetRolesForUser(userName));
        }

        public UserDto GetUserByEmail(string email)
        {
            string userName = _userRepository.GetUserNameByEmail(email);
            if (!string.IsNullOrEmpty(userName))
                return new UserDto() { UserName = userName };
            else return null;
        }

        public int InsertUser(UserDto user)
        {
            var id = _userRepository.InsertUser(_mapper.Map<User>(user));
            if (id > 0)
                _userRepository.SetRoleForUser(id, "User");
            return id;
        }

        public int GetOfficeId(int userId)
        {
           int id = _userRepository.GetOfficeId(userId);
           return id;
        }
    }
}
