namespace DoItYourself.Web.Areas.Administration.Controllers.Videos
{
    using System.Web.Mvc;

    public class VideosAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}