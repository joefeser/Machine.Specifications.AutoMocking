using Moq;

namespace NUnit.Specifications.AutoMocking.Moq
{
    using System;
    using NUnit.Framework;

    public abstract class Specification<TSubject> : Specification<TSubject, TSubject> 
    {
    }
    /// <summary>
    /// base class for writing specs using nunit with the subject dependencis mocked with Moq
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> : NUnitSpecification<TContract,TSubject> where TSubject : TContract
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            this.EstablishContext();

            try
            {
                this.When();
            }
            catch (Exception exc)
            {
                this.ExceptionThrown = exc;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
        }

        protected virtual Mock<T> MockedDependencyOf<T>() where T : class
        {
            return Mock.Get(DependencyOf<T>());
        }
    }
}