using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents Phase table from datebase.
    /// </summary>
    public class Project : EntityBase
    {
        public AreaMPZT AreaMPZT { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }

        public IList<ProjectFile> Files { get; set; }
    }
}
