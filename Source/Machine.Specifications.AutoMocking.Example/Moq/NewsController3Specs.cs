using Machine.Specifications.AutoMocking.Moq;
using Moq;

namespace Machine.Specifications.AutoMocking.Example.Moq
{
    /// <summary>
    /// Example specification for a class without a contract that uses property based DI
    /// </summary>
    public abstract class context_for_news_controller_3 : Specification<NewsController3>
    {
        protected static INewsService newsService;

        Establish context = () =>
            {
                newsService = An<INewsService>(); // An<> provides easy way to create a mock instance
                subject.NewsService = newsService; // subject is created automatically the first time it is accessed so properties can easily be set
            };
    }

    [Subject(typeof(NewsController3))]
    public class when_the_news_controller_3_is_told_to_display_the_default_view : context_for_news_controller_3
    {
        static string result;

        Establish context = () => Mock.Get(newsService).Setup(x => x.GetLatestHeadline()).Returns("The latest headline");

        Because of = () => result = subject.Index(); 

        It should_ask_the_news_service_for_the_latest_headline =
            () => newsService.was_told_to(x => x.GetLatestHeadline());

        It should_display_the_latest_headline = () => result.ShouldEqual("The latest headline");
    }
}