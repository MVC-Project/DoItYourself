namespace DoItYourself.Web.Controllers.Error
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}