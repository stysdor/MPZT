using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class ProposalRepositoryTests
    {
        private IProposalRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new ProposalRepository();
        }

        [TestMethod]
        public void IsNotNullGetProposalsTest()
        {
            var data = _repository.GetProposals(1);
            Assert.IsNotNull(data);
            Assert.AreEqual(data[0].User.UserName, "AKowalski");
        }

        [TestMethod]
        public void AddLikesTest()
        {
            var proposal1 = _repository.Get(1);
            var data = _repository.AddLikes(proposal1.Id);
            var proposal2 = _repository.Get(1);
            Assert.IsTrue(data);
            Assert.IsTrue((proposal2.Likes - proposal1.Likes) == 1);
        }

        [TestMethod]
        public void AddDislikesTest()
        {
            var proposal1 = _repository.Get(1);
            var data = _repository.AddDislikes(proposal1.Id);
            var proposal2 = _repository.Get(1);
            Assert.IsTrue(data);
            Assert.IsTrue((proposal2.Dislikes - proposal1.Dislikes) == 1);
        }

        [TestMethod]
        public void AddProposalTest()
        {
            Proposal proposal = new Proposal()
            {
                Description = "Mam wspaniałą propozycję!",
                AreaMPZT = new AreaMPZT() { Id = 1},
                User = new User() { Id = 1}
            };
            Assert.IsTrue(_repository.InsertOrUpdate(proposal) >= 1);
        }

    }   
}
