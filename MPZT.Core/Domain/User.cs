using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents User table from datebase.
    /// </summary>
    public class User: EntityBase
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ConfirmedEmail { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
