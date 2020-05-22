using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class Office: EntityBase
    {
        public virtual string OfficeName { get; set; }
        public virtual string OfficeAddress { get; set; }
        public virtual string OfficePhone { get; set; }
        public virtual string OfficeEmail { get; set; }
    }
}
