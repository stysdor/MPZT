using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Infrustructure.Mappers;
using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class ProjectServiceTests
    {
        private IProjectService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new ProjectService(AutoMapperConfig.Initialize());
        }

        [TestMethod]
        public void AddCommentTest()
        {
            CommentDto comment = new CommentDto()
            {
                Content = "Nic bym nie zmieniała. Plan uwględnia wszystkie potrzeby mieszkańców.",
                ProjectId = 1,
                UserId = 1,
            };
            var data = _service.AddComment(comment);
            Assert.IsTrue(data > 0);
        }
    }
}
