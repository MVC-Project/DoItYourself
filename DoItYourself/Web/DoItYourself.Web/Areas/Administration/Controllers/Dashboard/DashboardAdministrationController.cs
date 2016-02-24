namespace DoItYourself.Web.Areas.Administration.Controllers.Dashboard
{
    using System.Web.Mvc;

    public class DashboardAdministrationController : AdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}