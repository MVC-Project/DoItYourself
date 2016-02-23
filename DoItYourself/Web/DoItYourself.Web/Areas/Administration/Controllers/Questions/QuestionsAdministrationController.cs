namespace DoItYourself.Web.Areas.Administration.Controllers.Questions
{
    using System.Web.Mvc;

    public class QuestionsAdministrationController : KendoGridAdministrationController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}