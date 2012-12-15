using System;
using NUnit.Framework;
using Specifications.AutoMocking;
using Specifications.AutoMocking.Core;

namespace NUnit.Specifications.AutoMocking
{
    public abstract class NUnitSpecificationBase<TContract,TSubject,TMockFactory> : Specification<TContract, TSubject, TMockFactory>
        where TSubject : TContract
        where TMockFactory : IMockFactory, new()
    {
        protected Exception ExceptionThrown { get; set; }

        protected abstract void EstablishContext();

        protected abstract void When();

        [TestFixtureSetUp]
        public void Setup()
        {
            EstablishContext();

            try
            {
                When();
            }
            catch (Exception exc)
            {
                ExceptionThrown = exc;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
        }
    }
}