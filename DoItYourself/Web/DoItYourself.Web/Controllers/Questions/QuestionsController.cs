namespace DoItYourself.Web.Controllers.Questions
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    using ViewModels.Questions;

    public class QuestionsController : BaseController
    {
        private readonly IQuestionService questions;
        private readonly IUserService users;

        public QuestionsController(IUserService users, IQuestionService questions)
        {
            this.questions = questions;
            this.users = users;
        }

        public ActionResult Index()
        {
            if (this.ModelState.IsValid)
            {
                var questions = this.questions.AllApprovedQuestions().To<AllQuestionsViewModel>().ToList();

                var viewModel = new QuestionIndexViewModel
                {
                    Questions = questions
                };

                return this.View(viewModel);
            }

            return this.View();
        }

        public ActionResult Details(int id)
        {
            var question = this.questions.GetById(id);

            return this.View(question);
        }

        public ActionResult Add(QuestionCreateViewModel model)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.RedirectToAction("Login", "Accounnt");
            }

            if (this.ModelState.IsValid)
            {
                var question = new Question()
                {
                    Title = model.Title,
                    Content = model.Content,
                    IsApproved = true,
                    UserId = this.User.Identity.GetUserId(),
                    CategoryId = 47,
                    CreatedOn = DateTime.Now
                };

                this.questions.AddQuestion(question);
            }

            return this.View();
        }
    }
}