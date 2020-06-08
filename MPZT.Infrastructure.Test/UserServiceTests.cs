using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Infrustructure.Mappers;
using MPZT.Infrustructure.ModelDto;
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
        public void IsTrueValidateUserIfCorrectUserNameAndPasswordTest()
        {
            Assert.IsTrue(_service.ValidateUser("AKowalski", "1qaz2wsx"));
        }
        [TestMethod]
        public void IsFalseValidateUserIfCorrectUserNameAndWrongPasswordTest()
        {
            Assert.IsFalse(_service.ValidateUser("AKowalski", "baba"));
        }

        [TestMethod]
        public void IsFalseValidateUserIfWrongtUserNameAndCrrectPasswordTest()
        {
            Assert.IsFalse(_service.ValidateUser("Basia", "1qaz2wsx"));
        }

        [TestMethod]
        public void IsCorrectInsertUserTest()
        {
            UserDto user = new UserDto()
            {
                UserName = "Błażej",
                ConfirmedEmail = true,
                Email = "blazej123@op.pl",
                FirstName = "Błażej",
                LastName = "Dobrowolski",
                Password = "123456"
            };
            var id = _service.InsertUser(user);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void GetsCorrectUserByEmailServiceTest()
        {
           UserDto user = _service.GetUserByEmail("akowalski@o2.pl");
           Assert.IsNotNull(user);
           Assert.IsTrue(user.UserName == "AKowalski");
        }

        [TestMethod]
        public void GetsUserByEmailReturnsNullWhenWrongEmailServiceTest()
        {
            UserDto user = _service.GetUserByEmail("akowalskio2.pl");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetOfficeIdReturnCorrectOfficeIdByCorrectUserIdTest()
        {
            Assert.IsTrue(_service.GetOfficeId(3) == 1);
        }
        [TestMethod]
        public void GetOfficeIdReturn0ByInCorrectUserIdTest()
        {
            Assert.IsTrue(_service.GetOfficeId(99) == 0);
        }

    }
}
