using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Infrustructure.Mappers;
using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class AreaServiceTests
    {
        private IAreaService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new AreaService(AutoMapperConfig.Initialize());
        }

        [TestMethod]
        public void IsNotNullAreaListGeByLocationServiceTest()
        {
            LocationDto location = new LocationDto()
            {
                Wojewodztwo = "podkarpackie",
                City = "Tyczyn"
            };

            var list = _service.GetByLocation(location);
            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<AreaDto>));
        }

        public void IsEmptyAreaListGeByWrongLocationServiceTest()
        {
            LocationDto location = new LocationDto()
            {
                Wojewodztwo = "błędne",
            };

            var list = _service.GetByLocation(location);
            Assert.AreEqual(list.Count,0);
            Assert.IsInstanceOfType(list, typeof(List<AreaDto>));
        }

        [TestMethod]
        public void IsNotNullAreaListGetAllServiceTest()
        {
            var list = _service.GetAll();
            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<AreaDto>));
        }

        [TestMethod]
        public void IsNotNullAreaListGetByGeoPointServiceTest()
        {
            GeoPointSearchDto point =  new GeoPointSearchDto()
            {
                GeoPoint = new GeoPointDto() { Latitude = 49.96, Longitude = 22.03 },
                Range = 50
            };

            var list = _service.GetByGeoPoint(point);
            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<AreaDto>)); 
        }

        [TestMethod]
        public void IsEmptyAreaListGetByWrongGeoPointServiceTest()
        {
            GeoPointSearchDto point = new GeoPointSearchDto()
            {
                GeoPoint = new GeoPointDto() { Latitude = 20, Longitude = 10 },
                Range = 50
            };

            var list = _service.GetByGeoPoint(point);
            Assert.AreEqual(list.Count, 0);
            Assert.IsInstanceOfType(list, typeof(List<AreaDto>));
        }

        [TestMethod]
        public void InsertOrUpdateAreaReturnsIdOfNewAreaTest()
        {
            AreaDto area = new AreaDto()
            {
                ConsultationTime = new DateTime(2020, 06, 25, 16, 00, 00),
                ExpirationDate = new DateTime(2020, 07, 10),
                Location = new LocationDto() { Country = "Polska", Wojewodztwo = "podkarpackie", City = "Rzeszów", Powiat = "rzeszowki",Gmina = "Rzeszów", Dzielnica = "Drabinianka", Street = "Miła" },
                GeoPoints = new List<GeoPointDto>()
                {
                    new GeoPointDto() { Latitude = 22.004915, Longitude = 49.999166}
                },
                Name = "Zagospodarowanie ulicy Miłej na osiedlu Drabinianka",
                OfficeId = 2,
                PhaseId = 1
            };
            Assert.IsTrue(_service.InsertOrUpdate(area) > 0);
        }
    }
}
