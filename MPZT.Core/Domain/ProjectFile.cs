using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents ProjectFile table from datebase.
    /// </summary>
    public class ProjectFile
    {
        public Project Project { get; set; }
        public string NameFile { get; set; }
    }
}
