namespace DoItYourself.Web.Areas.Administration.Controllers.Categories
{
    using System.Web.Mvc;

    public class CategoriesAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}