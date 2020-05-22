using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPZT.GUI.DataAccess
{
    public class User
    {
        public List<Role> Roles { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}   