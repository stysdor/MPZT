using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MPZT.Api.Controllers
{
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/account/PostValidation")]
        [HttpPost]
        public IHttpActionResult PostValidation([FromBody] UserDto user)
        {
            return Json(_userService.ValidateUser(user.UserName, user.Password));
        }

        [Route("api/account/GetUser/{userName}")]
        [HttpGet]
        public IHttpActionResult GetUser(string userName)
        {
            return Json(_userService.GetUser(userName));
        }

        [Route("api/account/GetRolesForUser/{userName}")]
        [HttpGet]
        public IHttpActionResult GetRolesForUser(string userName)
        {
            return Json(_userService.GetRolesForUser(userName));
        }
    }
}
