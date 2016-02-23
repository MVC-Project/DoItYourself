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
    public class QuestionServiceTests
    {
        private static readonly IQueryable<Question> mockedQuestions = new List<Question>().AsQueryable();

        private static Mock<IQuestionService> mockedQuestionsData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var mockedQuestionsService = new Mock<IQuestionService>();
            mockedQuestionsService.Setup(s => s.AllQuestions())
                .Returns(mockedQuestions);

            mockedQuestionsService.Setup(s => s.AddQuestion(It.IsAny<Question>()))
                .Verifiable();

            mockedQuestionsData = mockedQuestionsService;
        }

        [TestMethod]
        public void GetAllQuestionsShouldNotReturnNull()
        {
            IQueryable<Question> questions = mockedQuestionsData.Object.AllQuestions();
            Assert.AreNotEqual(null, questions);
        }

        [TestMethod]
        public void GetAllQuestionsWithDeletedShouldNotReturnNull()
        {
            IQueryable<Question> questions = mockedQuestionsData.Object.AllQuestionsWithDeleted();
            Assert.AreNotEqual(null, questions);
        }

        [TestMethod]
        public void AddQuestionShouldBeCalled()
        {
            mockedQuestionsData.Object.AddQuestion(new Question());
            mockedQuestionsData.Verify(s => s.AddQuestion(It.IsAny<Question>()));
        }
    }
}
