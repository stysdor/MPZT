using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class AreaRepositoryTests
    {
        private IAreaRepository _areaRepository;
        private List<Location> _locations;
        private List<GeoPoint> _geopoints;

        [TestInitialize]
        public void SetUp()
        {
            _areaRepository = new AreaRepository();
            _locations = new LocationRepository().GetByLocation(new Location()
            {
                City = "Tyczyn"
            });
            _geopoints = new List<GeoPoint>() {
                new GeoPoint()
                {
                    Id = 1,
                    Latitude = 49.96384,
                    Longitude = 22.03398
                }
            };
        }

        [TestMethod]
        public void IsNotNullAreaListGeByLocationRepositoryTest()
        {
            var data = _areaRepository.GetByLocation(_locations);
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<AreaMPZT>));
        }

        [TestMethod]
        public void IsEmptyAreaListGetByWrongLocationRepositoryTest()
        {
            var locations = new List<Location>() { new Location() { Country = "Niemcy" } };
            var data = _areaRepository.GetByLocation(locations);
            Assert.AreEqual(data.Count, 0);
        }

        [TestMethod]
        public void IsNotNullAreaListGetByGeoPointRepositoryTest()
        {
            var data = _areaRepository.GetByGeoPoint(_geopoints);
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<AreaMPZT>));
        }

        [TestMethod]
        public void IsNotNullAreaListGetAllAreaRepositoryTest()
        {
            var data = _areaRepository.GetAll();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<AreaMPZT>));
        }
    }
}
