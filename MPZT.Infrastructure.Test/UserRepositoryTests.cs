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

        [TestMethod]
        public void IsFalseWhenSetInvalidRoleNameTest()
        {
            string roleName = "Users";
            Assert.IsFalse(_repository.SetRoleForUser(1, roleName));
        }
        [TestMethod]
        public void IsTrueWhenSetCorrectRoleNameTest()
        {
            string roleName = "User";
            Assert.IsTrue(_repository.SetRoleForUser(6, roleName));
        }

        [TestMethod]
        public void IsFalseWhenSetCorrectRoleNameAndWrongUserIdTest()
        {
            string roleName = "User";
            Assert.IsFalse(_repository.SetRoleForUser(1050, roleName));
        }

        [TestMethod]
        public void IsItPossibleToInsertUserTest()
        {
            User user = new User()
            {
                UserName = "Nowak",
                Email = "nowak@onet.eu",
                FirstName = "Mateusz",
                LastName = "Nowak",
                ConfirmedEmail = true,
                Password = "nowak"
            };

            int id  = _repository.InsertUser(user);
            Assert.IsTrue(id > 0);

        }

        [TestMethod]
        public void IsTrueItGetsTheRightUserNameByEmailTest()
        {
            string email = "akowalski@o2.pl";
            Assert.IsTrue(_repository.GetUserNameByEmail(email) == "AKowalski");
        }

        [TestMethod]
        public void ReturnNullIfEmailDoesntExistInDatabaseTest()
        {
            string email = "ao2.pl";
            Assert.IsNull(_repository.GetUserNameByEmail(email));
        }

        [TestMethod]
        public void GetOfficeIdReturnCorrectOfficeIdByCorrectUserIdTest()
        {
            Assert.IsTrue(_repository.GetOfficeId(3) == 1);
        }
        [TestMethod]
        public void GetOfficeIdReturn0ByInCorrectUserIdTest()
        {
            Assert.IsTrue(_repository.GetOfficeId(99) == 0);
        }

    }
}
