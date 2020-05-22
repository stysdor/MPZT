using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    public interface IAreaRepository: IDataRepository<AreaMPZT>
    {

        List<AreaMPZT> GetByLocation(List<Location> locations);
        List<AreaMPZT> GetByGeoPoint(List<GeoPoint> points);
    }
}
