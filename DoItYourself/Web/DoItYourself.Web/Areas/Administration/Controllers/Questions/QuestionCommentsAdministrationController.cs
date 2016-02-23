namespace DoItYourself.Web.Areas.Administration.Controllers.Questions
{
    using System.Web.Mvc;

    public class QuestionCommentsAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}