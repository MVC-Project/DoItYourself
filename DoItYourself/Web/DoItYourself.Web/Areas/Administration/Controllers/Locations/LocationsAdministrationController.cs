namespace DoItYourself.Web.Areas.Administration.Controllers.Locations
{
    using System.Web.Mvc;

    public class LocationsAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}