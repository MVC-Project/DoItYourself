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
    public class CountryServiceTests
    {
        private static readonly IQueryable<Country> mockedCountries = new List<Country>().AsQueryable();

        private static Mock<ICountryService> mockedCountriesData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedCountriesService = new Mock<ICountryService>();
            mockedCountriesService.Setup(s => s.AllCountries())
                .Returns(mockedCountries);

            mockedCountriesService.Setup(s => s.AddCountry(It.IsAny<Country>()))
                .Verifiable();

            mockedCountriesData = mockedCountriesService;
        }

        [TestMethod]
        public void GetAllCountriesShouldNotReturnNull()
        {
            IQueryable<Country> countries = mockedCountriesData.Object.AllCountries();
            Assert.AreNotEqual(null, countries);
        }

        [TestMethod]
        public void GetAllCountriesWithDeletedShouldNotReturnNull()
        {
            IQueryable<Country> countries = mockedCountriesData.Object.AllCountriesWithDeleted();
            Assert.AreNotEqual(null, countries);
        }

        [TestMethod]
        public void AddCountryShouldBeCalled()
        {
            mockedCountriesData.Object.AddCountry(new Country());
            mockedCountriesData.Verify(s => s.AddCountry(It.IsAny<Country>()));
        }
    }
}
