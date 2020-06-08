using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents GeoPoint table from datebase.
    /// </summary>
    public class GeoPoint: EntityBase
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
