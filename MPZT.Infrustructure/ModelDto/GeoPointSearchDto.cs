using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.ModelDto
{
    public class GeoPointSearchDto
    {
        public GeoPointDto GeoPoint { get; set; }
        public int Range { get; set; }
    }
}
