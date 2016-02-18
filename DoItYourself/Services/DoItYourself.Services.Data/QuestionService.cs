namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class QuestionService : IQuestionService
    {
        private readonly IDbRepository<Question> questions;

        public QuestionService(IDbRepository<Question> questions)
        {
            this.questions = questions;
        }

        public IQueryable<Question> AllQuestions()
        {
            return this.questions.All();
        }

        public IQueryable<Question> AllApprovedQuestions()
        {
            return this.questions.All()
                .Where(question => question.IsApproved == true);
        }

        public IQueryable<Question> AllUnapprovedQuestions()
        {
            return this.questions.All()
                .Where(question => question.IsApproved == false);
        }

        public IQueryable<Question> AllQuestionsWithDeleted()
        {
            return this.questions.AllWithDeleted();
        }

        public Question GetById(int id)
        {
            return this.questions.GetById(id);
        }

        public IQueryable<Question> AllQuestionsByUser(User user)
        {
            var userId = user.Id;
            return this.questions.All()
                .Where(question => question.UserId == userId);
        }

        public IQueryable<Question> AllQuestionsByUserId(string userId)
        {
            return this.questions.All()
                .Where(question => question.UserId == userId);
        }

        public IQueryable<Question> AllQuestionsByCategoryName(string categoryName)
        {
            return this.questions.All()
                .Where(question => question.Category.Name == categoryName);
        }

        public IQueryable<Question> AllQuestionsByCategoryId(int categoryId)
        {
            return this.questions.All()
                .Where(question => question.CategoryId == categoryId);
        }

        public IQueryable<Question> TopNewestQuestions(int take = 3)
        {
            return this.questions.All()
                .OrderByDescending(question => question.CreatedOn)
                .Take(take);
        }

        public IQueryable<Question> TopCommentedQuestions(int take = 6)
        {
            return this.questions.All()
                .OrderByDescending(question => question.Comments.Count())
                .Take(take);
        }

        public void ApproveQuestion(int questionId)
        {
            var question = this.questions.All()
                .Where(qst => qst.IsApproved == false && qst.Id == questionId)
                .FirstOrDefault();

            question.IsApproved = true;
            this.questions.Update(question);
            this.questions.Save();
        }

        public void DeleteQuestion(Question question)
        {
            this.questions.Delete(question);
            this.questions.Save();
        }

        public void HardDeleteQuestion(Question question)
        {
            this.questions.HardDelete(question);
            this.questions.Save();
        }

        public void DeleteQuestionById(int id)
        {
            var question = this.questions.GetById(id);
            this.questions.Delete(question);
            this.questions.Save();
        }

        public void HardDeleteQuestionById(int id)
        {
            var question = this.questions.GetById(id);
            this.questions.HardDelete(question);
            this.questions.Save();
        }
    }
}
