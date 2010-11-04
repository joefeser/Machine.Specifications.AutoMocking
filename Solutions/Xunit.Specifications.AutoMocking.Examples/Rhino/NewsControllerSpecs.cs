using SharpTestsEx;
using Xunit.Specifications.AutoMocking.Rhino;

namespace Xunit.Specifications.AutoMocking.Example.Rhino
{
    using global::Rhino.Mocks;

    /// <summary>
    ///   Example specification for a class without a contract that uses constructor based DI
    /// </summary>
    public abstract class context_for_news_controller : Specification<NewsController>
    {
        protected static INewsService newsService;

        protected override void EstablishContext()
        {
            newsService = DependencyOf<INewsService>();

            // DependencyOf creates and registers a mock instance of the dependency
        }
    }

    public class when_the_news_controller_is_told_to_display_the_default_view : context_for_news_controller
    {
        private static string result;

        protected override void EstablishContext()
        {
            base.EstablishContext();
            newsService.Stub(x => x.GetLatestHeadline()).Return("The latest headline");
        }

        protected override void When()
        {
            result = subject.Index();

            // the subject has been created for us automatically, with all registered dependencies
        }

        [Fact]
        public void It_should_ask_the_news_service_for_the_latest_headline()
        {
            newsService.AssertWasCalled(x => x.GetLatestHeadline());
        }

        [Fact]
        public void It_should_display_the_latest_headline()
        {
            result.Should().Be("The latest headline");
        }
    }
}