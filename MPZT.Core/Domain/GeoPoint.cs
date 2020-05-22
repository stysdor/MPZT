using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class GeoPoint: EntityBase
    {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
    }
}
