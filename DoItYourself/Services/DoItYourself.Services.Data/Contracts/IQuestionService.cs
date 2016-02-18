namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IQuestionService
    {
        IQueryable<Question> AllQuestions();

        IQueryable<Question> AllApprovedQuestions();

        IQueryable<Question> AllUnapprovedQuestions();

        IQueryable<Question> AllQuestionsWithDeleted();

        IQueryable<Question> AllQuestionsByUser(User user);

        IQueryable<Question> AllQuestionsByUserId(string userId);

        IQueryable<Question> AllQuestionsByCategoryName(string categoryName);

        IQueryable<Question> AllQuestionsByCategoryId(int categoryId);

        IQueryable<Question> TopNewestQuestions(int take = 3);

        IQueryable<Question> TopCommentedQuestions(int take = 6);

        void ApproveQuestion(int questionId);

        void DeleteQuestion(Question question);

        void HardDeleteQuestion(Question question);

        void DeleteQuestionById(int id);

        void HardDeleteQuestionById(int id);

        void AddQuestion(Question question);
    }
}
