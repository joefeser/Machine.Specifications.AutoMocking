using System;
using Specifications.AutoMocking;
using Specifications.AutoMocking.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MSTest.Specifications.AutoMocking
{
    [TestClass]
    public abstract class MSTestSpecificationBase<TContract,TSubject,TMockFactory> : Specification<TContract, TSubject, TMockFactory>
        where TSubject : TContract
        where TMockFactory : IMockFactory, new()
    {
        protected Exception ExceptionThrown { get; set; }

        protected abstract void EstablishContext();

        protected abstract void When();

        [TestInitialize]
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
    }
}