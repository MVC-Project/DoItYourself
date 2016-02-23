namespace DoItYourself.Web.Areas.Administration.Controllers.Countries
{
    using System.Web.Mvc;

    public class CountriesAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}