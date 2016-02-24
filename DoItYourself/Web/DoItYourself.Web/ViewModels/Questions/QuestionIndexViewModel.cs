namespace DoItYourself.Web.ViewModels.Questions
{
    using System.Collections.Generic;

    public class QuestionIndexViewModel
    {
        public IEnumerable<AllQuestionsViewModel> Questions { get; set; }
    }
}
