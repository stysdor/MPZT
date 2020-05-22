using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.ModelDto
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ConsultationTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int OfficeId { get; set; }
        public LocationDto Location { get; set; }
        public ICollection<GeoPointDto> GeoPoints { get; set; }
        public int PhaseId { get; set; }
    }
}
 