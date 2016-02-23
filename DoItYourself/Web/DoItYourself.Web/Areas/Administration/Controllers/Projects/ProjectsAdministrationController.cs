namespace DoItYourself.Web.Areas.Administration.Controllers.Projects
{
    using System.Web.Mvc;

    public class ProjectsAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}