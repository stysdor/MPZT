using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.GUI.DataAccess;
using MPZT.GUI.Logic;

namespace MPZT.GUI.Test
{
    [TestClass]
    public class UserApiTest
    {
        private UserApi _userApi;
        [TestInitialize]
        public void SetUp()
        {
            _userApi = new UserApi();      
        }

        [TestMethod]
        public void GetUserReturnsCorrectUser()
        {
            string name = "AKowalski";
            var userByName = _userApi.GetUser(name);
            Assert.IsNotNull(userByName);
            Assert.IsTrue(userByName.Email == "akowalski@o2.pl");
            Assert.IsTrue(userByName.FirstName == "Adam");
            Assert.IsTrue(userByName.LastName == "Kowalski");
            Assert.IsTrue(userByName.Id == 1);
        }

        [TestMethod]
        public void GetUserReturnsNullWhenUserDoesntExist()
        {
            string name = "Błąd";
            var userByName = _userApi.GetUser(name);
            Assert.IsNull(userByName);
        }

        [TestMethod]
        public void GetRolesForUserReturnsCorrectList()
        {
            string name = "AKowalski";
            var roles = _userApi.GetRolesForUser(name);
            Assert.IsNotNull(roles);
            List<Role> list = new List<Role>()
            {
                new Role() { RoleId = 1, RoleName = "User"}
            };
            Assert.AreEqual(roles.Count, list.Count);
            Assert.IsTrue(roles[0].RoleId == list[0].RoleId && roles[0].RoleName == list[0].RoleName);
        }

        [TestMethod]
        public void GetRolesForUserReturnsEmptyListIfUserDoesntExistList()
        {
            string name = "Błąd";
            var roles = _userApi.GetRolesForUser(name);
            Assert.AreEqual(roles.Count,0);
        }

        [TestMethod]
        public void GetUserByEmailReturnsCorrectUser()
        {
            string email = "akowalski@o2.pl";
            var userByEmail = _userApi.GetUserByEmail(email);
            Assert.IsNotNull(userByEmail);
            Assert.IsTrue(userByEmail == "AKowalski");
        }

        [TestMethod]
        public void GetUserByEmailReturnsNullIfEmailIncorrect()
        {
            string email = "akowalskio2.pl";
            var userByEmail = _userApi.GetUserByEmail(email);
            Assert.IsNull(userByEmail);
        }

        [TestMethod]
        public void GetValidationReturnsTrueIfDataCorrect()
        {
            Assert.IsTrue(_userApi.GetValidation("Basia123", "1qaz2wsx"));
        }

        [TestMethod]
        public void GetValidationReturnsFalseIfUserNameDoesntExist()
        {
            Assert.IsFalse(_userApi.GetValidation("Błąd", "1qaz2wsx"));
        }

        [TestMethod]
        public void GetValidationReturnsFalseIfPasswordIncorrect()
        {
            Assert.IsFalse(_userApi.GetValidation("Basia123", "błąd"));
        }

        [TestMethod]
        public void GetValidationReturnsFalseIfAllDataIncorrect()
        {
            Assert.IsFalse(_userApi.GetValidation("bład", "błąd"));
        }

        [TestMethod]
        public void GetOfficeIdReturnCorrectOfficeIdByCorrectUserIdTest()
        {
            Assert.IsTrue(_userApi.GetOfficeIdByUserId(3) == 1);
        }
        [TestMethod]
        public void GetOfficeIdReturn0ByInCorrectUserIdTest()
        {
            Assert.IsTrue(_userApi.GetOfficeIdByUserId(99) == 0);
        }
    }
}

