using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents AreaMPZT table from datebase.
    /// </summary>
    public class AreaMPZT: EntityBase
    {

        public string Name { get; set; }
        public DateTime ConsultationTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Office Office { get; set; }
        public Location Location { get; set; }
        public ICollection<GeoPoint> GeoPoints { get; set; }
        public Phase Phase { get; set; }
    }
}
