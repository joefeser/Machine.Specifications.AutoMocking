using System;
using Specifications.AutoMocking;
using Specifications.AutoMocking.Core;

namespace Xunit.Specifications.AutoMocking
{
    public abstract class XUnitSpecificationBase<TContract,TSubject,TMockFactory> : 
        Specification<TContract, TSubject, TMockFactory>,
        IUseFixture<object>
        where TSubject : TContract
        where TMockFactory : IMockFactory, new()
    {
        protected Exception ExceptionThrown { get; set; }

        protected abstract void EstablishContext();

        protected abstract void When();

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
    }
}