namespace DoItYourself.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class QuestionCommentServiceTests
    {
        private static readonly IQueryable<QuestionComment> mockedQuestionComments = new List<QuestionComment>().AsQueryable();

        private static Mock<IQuestionCommentService> mockedQuestionCommentsData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedQuestionCommentsService = new Mock<IQuestionCommentService>();
            mockedQuestionCommentsService.Setup(s => s.AllQuestionComments())
                .Returns(mockedQuestionComments);

            mockedQuestionCommentsService.Setup(s => s.AddQuestionComment(It.IsAny<QuestionComment>()))
                .Verifiable();

            mockedQuestionCommentsData = mockedQuestionCommentsService;
        }

        [TestMethod]
        public void GetAllQuestionCommentsShouldNotReturnNull()
        {
            IQueryable<QuestionComment> questionComments = mockedQuestionCommentsData.Object.AllQuestionComments();
            Assert.AreNotEqual(null, questionComments);
        }

        [TestMethod]
        public void GetAllQuestionsWithDeletedShouldNotReturnNull()
        {
            IQueryable<QuestionComment> questionComments = mockedQuestionCommentsData.Object.AllQuestionCommentsWithDeleted();
            Assert.AreNotEqual(null, questionComments);
        }

        [TestMethod]
        public void AddQuestionCommentShouldBeCalled()
        {
            mockedQuestionCommentsData.Object.AddQuestionComment(new QuestionComment());
            mockedQuestionCommentsData.Verify(s => s.AddQuestionComment(It.IsAny<QuestionComment>()));
        }
    }
}
