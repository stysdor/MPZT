using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new UserRepository();
        }

        [TestMethod]
        public void ValidateUserTest()
        {
            User user = new User()
            {
                UserName = "AKowalski",
                Password = "1qaz2wsx"
            };

            User falseUser = new User()
            {
                UserName = "AKowalski",
                Password = "blabla"
            };

            Assert.IsTrue(_repository.ValidateUser(user.UserName, user.Password));
            Assert.IsFalse(_repository.ValidateUser(falseUser.UserName, falseUser.Password));

        }
    }
}
