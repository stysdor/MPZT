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

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                GeoPoint p = (GeoPoint)obj;
                return (Latitude == p.Latitude) && (Longitude == p.Longitude);
            }
        }
    }
}
