using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Services
{
    public interface IAreaService
    {

        AreaDto Get(int id);

        IList<AreaDto> GetAll();

        List<AreaDto> GetByLocation(LocationDto item);
        List<AreaDto> GetByGeoPoint(GeoPointSearchDto item);

        void InsertOrUpdate(AreaDto item);
    }
}
