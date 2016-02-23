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
    public class UserServiceTests
    {
        private static readonly IQueryable<User> mockedUsers = new List<User>().AsQueryable();

        private static Mock<IUserService> mockedUsersData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedUsersService = new Mock<IUserService>();
            mockedUsersService.Setup(s => s.AllUsers())
                .Returns(mockedUsers);

            mockedUsersData = mockedUsersService;
        }

        [TestMethod]
        public void GetAllUsersShouldNotReturnNull()
        {
            IQueryable<User> users = mockedUsersData.Object.AllUsers();
            Assert.AreNotEqual(null, users);
        }

        [TestMethod]
        public void GetAllUsersWithDeletedShouldNotReturnNull()
        {
            IQueryable<User> users = mockedUsersData.Object.AllUsersWithDeleted();
            Assert.AreNotEqual(null, users);
        }
    }
}
