using SharpTestsEx;
using Xunit.Specifications.AutoMocking.Moq;

namespace Xunit.Specifications.AutoMocking.Example.Moq
{
    using global::Moq;

    public class when_the_news_controller_is_told_to_display_the_default_view : Specification<NewsController>
    {
        private static string result;

        [Fact]
        public void It_should_ask_the_news_service_for_the_latest_headline()
        {
            MockedDependencyOf<INewsService>().Verify(x => x.GetLatestHeadline());
        }

        [Fact]
        public void It_should_display_the_latest_headline()
        {
            result.Should().Be("The latest headline");
        }

        protected override void EstablishContext()
        {
            MockedDependencyOf<INewsService>().Setup(x => x.GetLatestHeadline()).Returns("The latest headline");
        }

        protected override void When()
        {
            result = subject.Index();

            // the subject has been created for us automatically, with all registered dependencies
        }
    }
}