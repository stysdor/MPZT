using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Infrustructure.Mappers;
using MPZT.Infrustructure.Services;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new UserService(AutoMapperConfig.Initialize());
        }

        [TestMethod]
        public void ValidateUserTests()
        {
            Assert.IsTrue(_service.ValidateUser("AKowalski", "1qaz2wsx"));
        }
    }
}
