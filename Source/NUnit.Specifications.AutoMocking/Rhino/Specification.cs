namespace NUnit.Specifications.AutoMocking.Rhino
{
    using System;

    using Machine.Specifications.AutoMocking;
    using Machine.Specifications.AutoMocking.Rhino;

    using NUnit.Framework;

    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }
    /// <summary>
    /// base class for writing specs using nunit with the subject dependencis mocked with Rhino.Mocks
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> : Specification<TContract, TSubject, RhinoMocksMockFactory>
        where TSubject : TContract
    {
        protected Exception ExceptionThrown { get; private set; }

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

        protected abstract void EstablishContext();

        protected abstract void When();
    }
}