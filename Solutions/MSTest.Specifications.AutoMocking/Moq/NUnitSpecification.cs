using System;
using Specifications.AutoMocking;
using Specifications.AutoMocking.Moq;

namespace NUnit.Specifications.AutoMocking
{
    public abstract class NUnitSpecification<TContract, TSubject> : Specification<TContract, TSubject, MoqMocksMockFactory>
        where TSubject : TContract
    {
        protected Exception ExceptionThrown { get; set; }

        protected abstract void EstablishContext();

        protected abstract void When();
    }
}