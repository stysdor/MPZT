using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents Comment table from datebase.
    /// </summary>
    public class Comment : EntityBase
    {
        public string Content { get; set; }
        public User  User { get; set; }
        public Project Project { get; set; }
    }
}
