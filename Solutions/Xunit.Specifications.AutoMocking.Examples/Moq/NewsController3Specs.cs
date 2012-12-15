using SharpTestsEx;
using Xunit.Specifications.AutoMocking.Moq;

namespace Xunit.Specifications.AutoMocking.Example.Moq
{
    using global::Moq;


    /// <summary>
    ///   Example specification for a class without a contract that uses property based DI
    /// </summary>
    public abstract class context_for_news_controller_3 : Specification<NewsController3>
    {
        protected static INewsService newsService;

        protected override void EstablishContext()
        {
            newsService = An<INewsService>(); // An<> provides easy way to create a mock instance
            subject.NewsService = newsService;

            // subject is created automatically the first time [Test]public void It_is accessed so properties can easily be set
        }
    }

    public class when_the_news_controller_3_is_told_to_display_the_default_view : context_for_news_controller_3
    {
        private static string result;

        [Fact]
        public void It_should_ask_the_news_service_for_the_latest_headline()
        {
            Mock.Get(newsService).Verify(x => x.GetLatestHeadline());
        }

        [Fact]
        public void It_should_display_the_latest_headline()
        {
            result.Should().Be("The latest headline");
        }

        protected override void EstablishContext()
        {
            base.EstablishContext();
            Mock.Get(newsService).Setup(x => x.GetLatestHeadline()).Returns("The latest headline");
        }

        protected override void When()
        {
            result = subject.Index();
        }
    }
}