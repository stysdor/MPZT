using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class GeopointRepositoryTests
    {
        private IGeoPointRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new GeoPointRepository();
        }

        [TestMethod]
        public void GetGeopointsOfAreaTest()
        {
            var points = _repository.GetByArea(1);
            Assert.IsNotNull(points);
            Assert.AreEqual(1, points.Count);
            Assert.AreEqual(22.03398, points[0].Longitude);
        }

        [TestMethod]
        public void GetAllInRangeTest()
        {
            GeoPoint point = new GeoPoint()
            {
                Latitude = 49.963,
                Longitude = 22.033
            };
            var points = _repository.GetAllInRange(point, 50);
            Assert.IsNotNull(points);
            Assert.AreEqual(22.03398, points[0].Longitude);
        }
    }
}
