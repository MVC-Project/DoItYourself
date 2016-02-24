namespace DoItYourself.Web.Controllers.Questions
{
    using System.Web.Mvc;

    public class QuestionCommentController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}