using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Repositories;

namespace MPZT.Infrastructure.Test
{
    [TestClass]
    public class CommentRepositoryTests
    {
        private ICommentRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new CommentRepository();
        }

        [TestMethod]
        public void IsPossibleToInsertCommentTest()
        {
            Comment comment = new Comment()
            {
                Content = "Ale to już było",
                Project = new Project() { Id = 1 },
                User = new User() { Id = 1 }
            };

            Assert.IsTrue(_repository.InsertOrUpdate(comment) > 0);
        }
    }
}
