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
    public class RatingServiceTests
    {
        private static readonly IQueryable<Rating> mockedRatings = new List<Rating>().AsQueryable();

        private static Mock<IRatingService> mockedRatingsData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedRatingsService = new Mock<IRatingService>();
            mockedRatingsService.Setup(s => s.AllRatings())
                .Returns(mockedRatings);

            mockedRatingsService.Setup(s => s.AddRating(It.IsAny<Rating>()))
                .Verifiable();

            mockedRatingsData = mockedRatingsService;
        }

        [TestMethod]
        public void GetAllRatingsShouldNotReturnNull()
        {
            IQueryable<Rating> ratings = mockedRatingsData.Object.AllRatings();
            Assert.AreNotEqual(null, ratings);
        }

        [TestMethod]
        public void GetAllRatingsWithDeletedShouldNotReturnNull()
        {
            IQueryable<Rating> ratings = mockedRatingsData.Object.AllRatingWithDeleted();
            Assert.AreNotEqual(null, ratings);
        }

        [TestMethod]
        public void AddRatingShouldBeCalled()
        {
            mockedRatingsData.Object.AddRating(new Rating());
            mockedRatingsData.Verify(s => s.AddRating(It.IsAny<Rating>()));
        }
    }
}
