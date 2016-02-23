namespace DoItYourself.Web.Controllers.Rating
{
    using System.Web.Mvc;

    public class RatingController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}