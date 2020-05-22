using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class AreaMPZT: EntityBase
    {

        public virtual string Name { get; set; }
        public virtual DateTime ConsultationTime { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual Office Office { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<GeoPoint> GeoPoints { get; set; }
        public virtual Phase Phase { get; set; }
    }
}
