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
    public class CategoryServiceTests
    {
        private static readonly IQueryable<Category> mockedCategories = new List<Category>().AsQueryable();

        private static Mock<ICategoryService> mockedCategoriesData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedCategoriesService = new Mock<ICategoryService>();
            mockedCategoriesService.Setup(s => s.AllCategories())
                .Returns(mockedCategories);

            mockedCategoriesService.Setup(s => s.AddCategory(It.IsAny<Category>()))
                .Verifiable();

            mockedCategoriesData = mockedCategoriesService;
        }

        [TestMethod]
        public void GetAllCategoriesShouldNotReturnNull()
        {
            IQueryable<Category> categories = mockedCategoriesData.Object.AllCategories();
            Assert.AreNotEqual(null, categories);
        }

        [TestMethod]
        public void GetAllCategoriesWithDeletedShouldNotReturnNull()
        {
            IQueryable<Category> categories = mockedCategoriesData.Object.AllCategoriesWithDeleted();
            Assert.AreNotEqual(null, categories);
        }

        [TestMethod]
        public void AddCategoryShouldBeCalled()
        {
            mockedCategoriesData.Object.AddCategory(new Category());
            mockedCategoriesData.Verify(s => s.AddCategory(It.IsAny<Category>()));
        }
    }
}
