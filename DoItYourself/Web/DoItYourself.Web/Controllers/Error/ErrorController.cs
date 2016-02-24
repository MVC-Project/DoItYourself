namespace DoItYourself.Web.Controllers.Error
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult InternalServer()
        {
            return this.View();
        }
    }
}