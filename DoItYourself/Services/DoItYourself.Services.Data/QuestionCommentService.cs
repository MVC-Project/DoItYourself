namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class QuestionCommentService : IQuestionCommentService
    {
        private readonly IDbRepository<QuestionComment> questionComments;

        public QuestionCommentService(IDbRepository<QuestionComment> questionComments)
        {
            this.questionComments = questionComments;
        }

        public IQueryable<QuestionComment> AllQuestionComments()
        {
            return this.questionComments.All();
        }

        public IQueryable<QuestionComment> AllQuestionCommentsWithDeleted()
        {
            return this.questionComments.AllWithDeleted();
        }

        public QuestionComment GetById(int id)
        {
            return this.questionComments.GetById(id);
        }

        public IQueryable<QuestionComment> AllQuestionCommentsByUser(User user)
        {
            var userId = user.Id;
            return this.questionComments.All()
                .Where(questionComment => questionComment.UserId == userId);
        }

        public IQueryable<QuestionComment> AllQuestionCommentsByUserId(string userId)
        {
            return this.questionComments.All()
                .Where(questionComment => questionComment.UserId == userId);
        }

        public IQueryable<QuestionComment> AllQuestionCommentsForQuestion(Question question)
        {
            var questionId = question.Id;
            return this.questionComments.All()
                .Where(questionComment => questionComment.QuestionId == questionId);
        }

        public IQueryable<QuestionComment> AllQuestionCommentsForQuestionId(int questionId)
        {
            return this.questionComments.All()
                .Where(questionComment => questionComment.QuestionId == questionId);
        }

        public IQueryable<QuestionComment> TopNewestQuestionComments(int take = 10)
        {
            return this.questionComments.All().
                OrderByDescending(questionComment => questionComment.CreatedOn)
                .Take(take);
        }

        public void DeleteQuestionComment(QuestionComment questionComment)
        {
            this.questionComments.Delete(questionComment);
            this.questionComments.Save();
        }

        public void HardDeleteQuestionComment(QuestionComment questionComment)
        {
            this.questionComments.HardDelete(questionComment);
            this.questionComments.Save();
        }

        public void DeleteQuestionCommentById(int id)
        {
            var questionComment = this.questionComments.GetById(id);
            this.questionComments.Delete(questionComment);
            this.questionComments.Save();
        }

        public void HardDeleteQuestionCommentById(int id)
        {
            var questionComment = this.questionComments.GetById(id);
            this.questionComments.Delete(questionComment);
            this.questionComments.Save();
        }

        public void AddQuestionComment(QuestionComment questionComment)
        {
            this.questionComments.Add(questionComment);
            this.questionComments.Save();
        }

        public void UpdateQuestionCommentContent(int questionCommentId, string updatedContent)
        {
            var questionComment = this.questionComments.All()
                .Where(qstComment => qstComment.Id == questionCommentId)
                .FirstOrDefault();

            questionComment.Content = updatedContent;
            this.questionComments.Update(questionComment);
            this.questionComments.Save();
        }
    }
}
