using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrustructure.Services
{
    public class AreaService: IAreaService
    {
        private IAreaRepository _areaRepository;
        private ILocationRepository _locationRepository;
        private IGeoPointRepository _geopointRepository;
        private readonly IMapper _mapper;

        public AreaService(IMapper mapper)
        {
            _areaRepository = new AreaRepository();
            _locationRepository = new LocationRepository();
            _geopointRepository = new GeoPointRepository();
            _mapper = mapper;
        }

        public AreaDto Get(int id)
        {
            var area = _areaRepository.Get(id);
            return _mapper.Map<AreaDto>(area);
        }

        public IList<AreaDto> GetAll()
        {
            var areas = _areaRepository.GetAll();
            return _mapper.Map<IList<AreaDto>>(areas);
        }

        public List<AreaDto> GetByLocation(LocationDto item)
        {
            var location = _mapper.Map<Location>(item);
            var locationList = _locationRepository.GetByLocation(location);
            var list = _areaRepository.GetByLocation(locationList);
            list = fillAreasGeopoints(list);
            return _mapper.Map<List<AreaDto>>(list);

        }
        public List<AreaDto> GetByGeoPoint(GeoPointSearchDto item)
        {
            var geopoint = _mapper.Map<GeoPoint>(item.GeoPoint);
            var pointList = _geopointRepository.GetAllInRange(geopoint, item.Range);
            var list = _areaRepository.GetByGeoPoint(pointList);
            list = fillAreasGeopoints(list);
            return _mapper.Map<List<AreaDto>>(list);
        }

        private List<AreaMPZT> fillAreasGeopoints(List<AreaMPZT> list)
        {
            foreach (var item in list)
            {
                item.GeoPoints = _geopointRepository.GetByArea(item.Id);
            }
            return list;
        }

        public int InsertOrUpdate(AreaDto item)
        {
            var area = _mapper.Map<AreaMPZT>(item);

            if (!(item.Location == null))
            {
                var id = _locationRepository.InsertOrUpdate(area.Location);
                area.Location.Id = id;
            }

            int areaId = _areaRepository.InsertOrUpdate(area);

            if (area.GeoPoints.Count > 0)
            {
                var geopoints = new List<GeoPoint>();
                foreach (GeoPointDto point in item.GeoPoints)
                {
                    if (point.Latitude > 0 && point.Longitude > 0)
                    {
                        var geopoint = _mapper.Map<GeoPoint>(point);
                        var pointId = _geopointRepository.InsertOrUpdate(geopoint);
                        geopoint.Id = pointId;
                        geopoints.Add(geopoint);
                    }
                    _areaRepository.AddGeoPointsToArea(geopoints, areaId);
                }
            }   
            return areaId;
        }

        
    }
}
