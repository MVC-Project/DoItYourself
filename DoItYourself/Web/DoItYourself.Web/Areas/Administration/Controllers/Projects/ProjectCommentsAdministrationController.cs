namespace DoItYourself.Web.Areas.Administration.Controllers.Projects
{
    using System.Web.Mvc;

    public class ProjectCommentsAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}