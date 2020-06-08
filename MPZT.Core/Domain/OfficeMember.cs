using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents OfficeMember table from datebase.
    /// </summary>
    public class OfficeMember: User
    {
        public Office Office { get; set; }
    }
}
