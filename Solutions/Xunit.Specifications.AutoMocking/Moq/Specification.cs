using System;
using Moq;
using Specifications.AutoMocking;
using Specifications.AutoMocking.Moq;

namespace Xunit.Specifications.AutoMocking.Moq
{
    public abstract class Specification<TSubject> : Specification<TSubject, TSubject> 
    {
    }
    /// <summary>
    /// base class for writing specs using xunit with the subject dependencis mocked with Moq
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> : 
        Specification<TContract, TSubject, MoqMocksMockFactory> ,IUseFixture<object>
        where TSubject : TContract
    {
        protected virtual Mock<T> MockedDependencyOf<T>() where T : class
        {
            return Mock.Get(DependencyOf<T>());
        }

        #region IUseFixture<object> Members

        public void SetFixture(object unused)
        {
            try
            {
                EstablishContext();

                When();
            }
            catch (Exception e)
            {
                ExceptionThrown = e;
            }
        }
        #endregion

        protected Exception ExceptionThrown { get; set; }

        protected abstract void EstablishContext();

        protected abstract void When();
    }
}