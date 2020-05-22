using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class Project : EntityBase
    {
        public virtual AreaMPZT AreaMPZT { get; set; }
        public virtual string Number { get; set; }
        public virtual string Description { get; set; }

        public IList<ProjectFile> Files { get; set; }
    }
}
