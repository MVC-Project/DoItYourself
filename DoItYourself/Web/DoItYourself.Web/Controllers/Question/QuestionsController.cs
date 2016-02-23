namespace DoItYourself.Web.Controllers.Question
{
    using System.Web.Mvc;

    public class QuestionsController : BaseController
    {

        public ActionResult Index()
        {
            return this.View();
        }
    }
}