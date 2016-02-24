namespace DoItYourself.Web.Controllers.Project
{
    using System.Web.Mvc;

    public class ProjectsController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult Add()
        {
            return this.View();
        }
    }
}