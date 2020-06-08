using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class LocationRepositoryTests
    {
        private ILocationRepository _repository;
        private Location _location;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new LocationRepository();
        }

        [TestMethod]
        public void IsNotNullGetByLocationTest()
        {
            _location = new Location()
            {
                Wojewodztwo = "podkarpackie",
                City = "Tyczyn"
            };

            var data = _repository.GetByLocation(_location);
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<Location>));
        }

        [TestMethod]
        public void IsEmptyListGetByWrongLocationTest()
        {
            _location = new Location()
            {
                Wojewodztwo = "błędne",
            };

            var data = _repository.GetByLocation(_location);
            Assert.AreEqual(data.Count, 0);
            Assert.IsInstanceOfType(data, typeof(List<Location>));
        }
    }
}
