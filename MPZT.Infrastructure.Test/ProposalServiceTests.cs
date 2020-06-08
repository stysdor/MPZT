using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Infrustructure.Mappers;
using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class ProposalServiceTests
    {
        private IProposalService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new ProposalService(AutoMapperConfig.Initialize());
        }

        [TestMethod]
        public void IsNotNullGetProposalsByAreaIdTest()
        {
            var list = _service.GetProposals(1);
            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<ProposalDto>));
        }

        [TestMethod]
        public void IsEmptyListGetProposalsByWrongAreaIdTest()
        {
            var list = _service.GetProposals(9999);
            Assert.AreEqual(list.Count, 0);
            Assert.IsInstanceOfType(list, typeof(List<ProposalDto>));
        }
    }
}
