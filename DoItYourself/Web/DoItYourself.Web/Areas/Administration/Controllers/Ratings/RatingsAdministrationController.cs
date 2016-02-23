namespace DoItYourself.Web.Areas.Administration.Controllers.Ratings
{
    using System.Web.Mvc;

    public class RatingsAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}