using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSTest.Specifications.AutoMocking.Moq;
using SharpTestsEx;

namespace MSTest.Specifications.AutoMocking.Example.Moq
{
    /// <summary>
    ///   Example specification for a class without a contract that manually creates subject
    /// </summary>
    public abstract class context_for_news_controller_2 : Specification<NewsController2>
    {
        private static INewsService newsService;

        public static INewsService NewsService
        {
            get
            {
                return newsService ?? (newsService = An<INewsService>());
            }
        }

        protected override NewsController2 CreateSubject()
        {
            return new NewsController2(NewsService); // the CreateSubject can be override if necessary
        }
    }

    [TestClass]
    public class when_the_news_controller_2_is_told_to_display_the_default_view : context_for_news_controller_2
    {
        private static string result;

        // the subject has been created for us automatically, with all registered dependencies

        [TestMethod]
        public void It_should_ask_the_news_service_for_the_latest_headline()
        {
            Mock.Get(NewsService).Verify(x => x.GetLatestHeadline());
        }

        [TestMethod]
        public void It_should_display_the_latest_headline()
        {
            result.Should().Be("The latest headline");
        }

        protected override void EstablishContext()
        {
            Mock.Get(NewsService).Setup(x => x.GetLatestHeadline()).Returns("The latest headline");
        }

        protected override void When()
        {
            result = subject.Index();
        }
    }
}