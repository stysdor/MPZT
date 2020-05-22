using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class OfficeMember: User
    {
        public virtual Office Office { get; set; }
    }
}
