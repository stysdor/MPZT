using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class Comment : EntityBase
    {
        public virtual string Content { get; set; }
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
