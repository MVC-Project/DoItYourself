namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class CountryService : ICountryService
    {
        private readonly IDbRepository<Country> countries;

        public CountryService(IDbRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> AllCountries()
        {
            return this.countries.All()
                .OrderBy(country => country.Name);
        }

        public IQueryable<Country> AllCountriesWithDeleted()
        {
            return this.countries.AllWithDeleted()
                .OrderBy(country => country.Name);
        }

        public IQueryable<string> AllCountriesNames()
        {
            return this.countries.All()
                .OrderBy(country => country.Name)
                .Select(country => country.Name);
        }

        public IQueryable<string> AllCountriesAbbreviations()
        {
            return this.countries.All()
                .OrderBy(country => country.Abbreviation)
                .Select(country => country.Abbreviation);
        }

        public Country GetById(int id)
        {
            return this.countries.GetById(id);
        }

        public string GetCountryNameByAbbreviation(string abbreviation)
        {
            return this.countries.All()
                .Where(country => country.Abbreviation == abbreviation)
                .Select(country => country.Name)
                .ToString();
        }

        public string GetCountryAbbreviationByName(string name)
        {
            return this.countries.All()
                .Where(country => country.Name == name)
                .Select(country => country.Abbreviation)
                .ToString();
        }

        public void DeleteCountry(Country country)
        {
            this.countries.Delete(country);
            this.countries.Save();
        }

        public void HardDeleteCountry(Country country)
        {
            this.countries.HardDelete(country);
            this.countries.Save();
        }

        public void DeleteCountryById(int id)
        {
            var country = this.countries.GetById(id);
            this.countries.Delete(country);
            this.countries.Save();
        }

        public void HardDeleteCountryById(int id)
        {
            var country = this.countries.GetById(id);
            this.countries.HardDelete(country);
            this.countries.Save();
        }

        public void AddCountry(Country country)
        {
            this.countries.Add(country);
            this.countries.Save();
        }
    }
}
