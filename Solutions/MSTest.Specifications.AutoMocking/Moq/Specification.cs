using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Specifications.AutoMocking.Moq;

namespace MSTest.Specifications.AutoMocking.Moq
{
    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }
    /// <summary>
    /// base class for writing specs using nunit with the subject dependencies mocked with Moq
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> : MSTestSpecificationBase<TContract, TSubject, MoqMocksMockFactory>
        where TSubject : TContract
    {
        protected virtual Mock<T> MockedDependencyOf<T>() where T : class
        {
            return Mock.Get(DependencyOf<T>());
        }
    }
}