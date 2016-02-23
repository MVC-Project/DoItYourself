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
    public class LocationServiceTests
    {
        private static readonly IQueryable<Location> mockedLocations = new List<Location>().AsQueryable();

        private static Mock<ILocationService> mockedLocationsData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedLocationsService = new Mock<ILocationService>();
            mockedLocationsService.Setup(s => s.AllLocations())
                .Returns(mockedLocations);

            mockedLocationsService.Setup(s => s.AddLocation(It.IsAny<Location>()))
                .Verifiable();

            mockedLocationsData = mockedLocationsService;
        }

        [TestMethod]
        public void GetAllLocationsShouldNotReturnNull()
        {
            IQueryable<Location> locations = mockedLocationsData.Object.AllLocations();
            Assert.AreNotEqual(null, locations);
        }

        [TestMethod]
        public void GetAllLocationsWithDeletedShouldNotReturnNull()
        {
            IQueryable<Location> locations = mockedLocationsData.Object.AllLocationsWithDeleted();
            Assert.AreNotEqual(null, locations);
        }

        [TestMethod]
        public void AddLocationShouldBeCalled()
        {
            mockedLocationsData.Object.AddLocation(new Location());
            mockedLocationsData.Verify(s => s.AddLocation(It.IsAny<Location>()));
        }
    }
}
