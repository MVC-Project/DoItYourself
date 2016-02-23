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
    public class ProjectServiceTests
    {
        private static readonly IQueryable<Project> mockedProjects = new List<Project>().AsQueryable();

        private static Mock<IProjectService> mockedProjectsData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedProjectsService = new Mock<IProjectService>();
            mockedProjectsService.Setup(s => s.AllProjects())
                .Returns(mockedProjects);

            mockedProjectsService.Setup(s => s.AddProject(It.IsAny<Project>()))
                .Verifiable();

            mockedProjectsData = mockedProjectsService;
        }

        [TestMethod]
        public void GetAllCProjectsShouldNotReturnNull()
        {
            IQueryable<Project> projects = mockedProjectsData.Object.AllProjects();
            Assert.AreNotEqual(null, projects);
        }

        [TestMethod]
        public void GetAllProjectsWithDeletedShouldNotReturnNull()
        {
            IQueryable<Project> projects = mockedProjectsData.Object.AllProjectsWithDeleted();
            Assert.AreNotEqual(null, projects);
        }

        [TestMethod]
        public void AddProjectShouldBeCalled()
        {
            mockedProjectsData.Object.AddProject(new Project());
            mockedProjectsData.Verify(s => s.AddProject(It.IsAny<Project>()));
        }
    }
}
