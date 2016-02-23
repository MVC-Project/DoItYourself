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
    public class ImageServiceTests
    {
        private static readonly IQueryable<Image> mockedImages= new List<Image>().AsQueryable();

        private static Mock<IImageService> mockedImagesData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedImagesService = new Mock<IImageService>();
            mockedImagesService.Setup(s => s.AllImages())
                .Returns(mockedImages);

            mockedImagesService.Setup(s => s.AddImage(It.IsAny<Image>()))
                .Verifiable();

            mockedImagesData = mockedImagesService;
        }

        [TestMethod]
        public void GetAllImagesShouldNotReturnNull()
        {
            IQueryable<Image> images = mockedImagesData.Object.AllImages();
            Assert.AreNotEqual(null, images);
        }

        [TestMethod]
        public void GetAllImagesWithDeletedShouldNotReturnNull()
        {
            IQueryable<Image> images = mockedImagesData.Object.AllImagesWithDeleted();
            Assert.AreNotEqual(null, images);
        }

        [TestMethod]
        public void AddImageShouldBeCalled()
        {
            mockedImagesData.Object.AddImage(new Image());
            mockedImagesData.Verify(s => s.AddImage(It.IsAny<Image>()));
        }
    }
}
