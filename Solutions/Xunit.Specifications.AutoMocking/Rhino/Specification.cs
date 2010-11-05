using System;
using Specifications.AutoMocking.Rhino;

namespace Xunit.Specifications.AutoMocking.Rhino
{
    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }
    /// <summary>
    /// base class for writing specs using xunit with the subject dependencies mocked with Rhino.Mocks
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> :
        XUnitSpecificationBase<TContract, TSubject, RhinoMocksMockFactory>
        where TSubject : TContract
    {
    }
}