namespace DoItYourself.Web.Areas.Administration.Controllers.Users
{
    using System.Web.Mvc;

    public class UsersAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}