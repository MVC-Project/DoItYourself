namespace DoItYourself.Web.Infrastructure.Populator
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetCategories();

        IEnumerable<SelectListItem> GetCountriesNames();

        IEnumerable<SelectListItem> GetCountriesAbbreviation();
    }
}
