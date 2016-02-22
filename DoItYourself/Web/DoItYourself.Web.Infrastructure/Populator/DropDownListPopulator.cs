namespace DoItYourself.Web.Infrastructure.Populator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using Services.Web;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private ICategoryService categories;
        private ICountryService countries;
        private ICacheService cache;

        public DropDownListPopulator()
        {
        }

        public DropDownListPopulator(ICategoryService categories, ICountryService countries, ICacheService cache)
        {
            this.categories = categories;
            this.countries = countries;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.cache.Get<IEnumerable<SelectListItem>>(
                "categories",
                () =>
                {
                    var categoriesList = new List<SelectListItem>
                    {
                          {
                              new SelectListItem { Text = "Select category", Value = "-1", Selected = true }
                          },
                    };

                    categoriesList.AddRange(this.categories.AllCategories()
                       .Select(category => new SelectListItem
                       {
                           Value = category.Id.ToString(),
                           Text = category.Name
                       }));

                    return categoriesList;
                },
                24 * 60 * 60);

            return categories;
        }

        public IEnumerable<SelectListItem> GetCountriesNames()
        {
            var countriesNames = this.cache.Get<IEnumerable<SelectListItem>>(
               "countriesNames",
               () =>
               {
                   var countriesNamesList = new List<SelectListItem>
                   {
                          {
                              new SelectListItem { Text = "Select category", Value = "-1", Selected = true }
                          },
                   };

                   countriesNamesList.AddRange(this.countries.AllCountries()
                      .Select(country => new SelectListItem
                      {
                          Value = country.Id.ToString(),
                          Text = country.Name
                      }));

                   return countriesNamesList;
               },
               72 * 60 * 60);

            return countriesNames;
        }

        public IEnumerable<SelectListItem> GetCountriesAbbreviation()
        {
            var countriesAbbreviation = this.cache.Get<IEnumerable<SelectListItem>>(
               "countriesNames",
               () =>
               {
                   var countriesAbbreviationList = new List<SelectListItem>
                   {
                          {
                              new SelectListItem { Text = "Select category", Value = "-1", Selected = true }
                          },
                   };

                   countriesAbbreviationList.AddRange(this.countries.AllCountries()
                      .Select(country => new SelectListItem
                      {
                          Value = country.Id.ToString(),
                          Text = country.Abbreviation
                      }));

                   return countriesAbbreviationList;
               },
               72 * 60 * 60);

            return countriesAbbreviation;
        }
    }
}
