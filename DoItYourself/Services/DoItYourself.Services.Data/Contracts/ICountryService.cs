namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface ICountryService
    {
        IQueryable<Country> AllCountries();

        IQueryable<Country> AllCountriesWithDeleted();

        IQueryable<string> AllCountriesNames();

        IQueryable<string> AllCountriesAbbreviations();

        Country GetById(int id);

        string GetCountryNameByAbbreviation(string abbreviation);

        string GetCountryAbbreviationByName(string name);

        void DeleteCountry(Country country);

        void HardDeleteCountry(Country country);

        void DeleteCountryById(int id);

        void HardDeleteCountryById(int id);

        void AddCountry(Country country);
    }
}
