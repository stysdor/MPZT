using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    public interface IGeoPointRepository: IDataRepository<GeoPoint>
    {
        List<GeoPoint> GetAllInRange(GeoPoint point, int range);
        List<GeoPoint> GetByArea(int areaId);
    }
}
