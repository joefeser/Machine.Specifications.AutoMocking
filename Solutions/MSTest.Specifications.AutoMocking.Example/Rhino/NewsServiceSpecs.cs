using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Specifications.AutoMocking.Rhino;

namespace MSTest.Specifications.AutoMocking.Example.Rhino
{

    using SharpTestsEx;

    /// <summary>
    ///   Example specification for a class with a contract that uses constructor based DI
    /// </summary>
    public abstract class context_for_news_service : Specification<INewsService, NewsService>
    {
        protected override void EstablishContext()
        {
            var newsHeadlines = new List<string> { "Yesterday's headline", "Today's headline" };

            ProvideBasicConstructorArgument(newsHeadlines); // manually add a required simple constructor argument
        }
    }

    [TestClass]
    public class when_the_news_service_is_asked_for_the_latest_headline : context_for_news_service
    {
        private static string result;

        // subject is created automatically and returned as an INewsService so we are coding against the interface

        [TestMethod]
        public void It_should_return_the_latest_headline()
        {
            result.Should().Be("Today's headline");
        }

        protected override void When()
        {
            result = subject.GetLatestHeadline();
        }
    }

    [TestClass]
    public class when_the_news_service_is_asked_for_all_the_headlines : context_for_news_service
    {
        private static List<string> result;

        [TestMethod]
        public void It_should_return_the_list_of_all_headlines()
        {
            result.Count.Should().Be(2);
        }

        protected override void When()
        {
            result = subject.GetAllHeadlines();
        }
    }
}