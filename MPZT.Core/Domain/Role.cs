using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents Role table from datebase.
    /// </summary>
    public class Role: EntityBase
    {
        public string Name { get; set; }
    }
}
