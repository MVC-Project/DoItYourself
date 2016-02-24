namespace DoItYourself.Web.Controllers.Question
{
    using System.Web.Mvc;

    public class QuestionsController : BaseController
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