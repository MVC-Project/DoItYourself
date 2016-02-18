namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface IQuestionCommentService
    {
        IQueryable<QuestionComment> AllQuestionComments();

        IQueryable<QuestionComment> AllQuestionCommentsWithDeleted();

        QuestionComment GetById(int id);

        IQueryable<QuestionComment> AllQuestionCommentsByUser(User user);

        IQueryable<QuestionComment> AllQuestionCommentsByUserId(string userId);

        IQueryable<QuestionComment> AllQuestionCommentsForQuestion(Question question);

        IQueryable<QuestionComment> AllQuestionCommentsForQuestionId(int questionId);

        IQueryable<QuestionComment> TopNewestQuestionComments(int take = 10);

        void DeleteQuestionComment(QuestionComment questionComment);

        void HardDeleteQuestionComment(QuestionComment questionComment);

        void DeleteQuestionCommentById(int id);

        void HardDeleteQuestionCommentById(int id);

        void AddQuestionComment(QuestionComment questionComment);

        void UpdateQuestionCommentContent(int questionCommentId, string updatedContent);
    }
}
