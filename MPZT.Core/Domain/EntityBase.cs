using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Base class for all classes representing tables from database for generic use.
    /// </summary>
    public abstract class EntityBase
    {
        public int Id { get; set; }
    }
}
