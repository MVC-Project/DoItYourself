namespace DoItYourself.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ProjectCommentServiceTests
    {
        private static readonly IQueryable<ProjectComment> mockedProjectComments = new List<ProjectComment>().AsQueryable();

        private static Mock<IProjectCommentService> mockedProjectCommentsData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedProjectCommentsService = new Mock<IProjectCommentService>();
            mockedProjectCommentsService.Setup(s => s.AllProjectComments())
                .Returns(mockedProjectComments);

            mockedProjectCommentsService.Setup(s => s.AddProjectComment(It.IsAny<ProjectComment>()))
                .Verifiable();

            mockedProjectCommentsData = mockedProjectCommentsService;
        }

        [TestMethod]
        public void GetAllProjectCommentsShouldNotReturnNull()
        {
            IQueryable<ProjectComment> projectComments = mockedProjectCommentsData.Object.AllProjectComments();
            Assert.AreNotEqual(null, projectComments);
        }

        [TestMethod]
        public void GetAllCategoriesWithDeletedShouldNotReturnNull()
        {
            IQueryable<ProjectComment> projectComments = mockedProjectCommentsData.Object.AllProjectCommentsWithDeleted();
            Assert.AreNotEqual(null, projectComments);
        }

        [TestMethod]
        public void AddProjectCommentShouldBeCalled()
        {
            mockedProjectCommentsData.Object.AddProjectComment(new ProjectComment());
            mockedProjectCommentsData.Verify(s => s.AddProjectComment(It.IsAny<ProjectComment>()));
        }
    }
}
