using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents Office table from datebase.
    /// </summary>
    public class Office: EntityBase
    {
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeEmail { get; set; }
    }
}
