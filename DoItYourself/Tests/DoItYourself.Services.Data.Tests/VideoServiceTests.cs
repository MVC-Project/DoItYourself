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
    public class VideoServiceTests
    {
        private static readonly IQueryable<Video> mockedVideos = new List<Video>().AsQueryable();

        private static Mock<IVideoService> mockedVideosData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedVideosService = new Mock<IVideoService>();
            mockedVideosService.Setup(s => s.AllVideos())
                .Returns(mockedVideos);

            mockedVideosService.Setup(s => s.AddVideo(It.IsAny<Video>()))
                .Verifiable();

            mockedVideosData = mockedVideosService;
        }

        [TestMethod]
        public void GetAllVideosShouldNotReturnNull()
        {
            IQueryable<Video> videos = mockedVideosData.Object.AllVideos();
            Assert.AreNotEqual(null, videos);
        }

        [TestMethod]
        public void GetAllVideosWithDeletedShouldNotReturnNull()
        {
            IQueryable<Video> videos = mockedVideosData.Object.AllVideosWithDeleted();
            Assert.AreNotEqual(null, videos);
        }

        [TestMethod]
        public void AddVideoShouldBeCalled()
        {
            mockedVideosData.Object.AddVideo(new Video());
            mockedVideosData.Verify(s => s.AddVideo(It.IsAny<Video>()));
        }
    }
}
