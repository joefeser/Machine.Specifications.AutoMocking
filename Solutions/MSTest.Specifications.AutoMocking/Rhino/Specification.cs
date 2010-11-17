using MSTest.Specifications.AutoMocking;
using Specifications.AutoMocking.Rhino;

namespace MSTest.Specifications.AutoMocking.Rhino
{
    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }
    /// <summary>
    /// base class for writing specs using nunit with the subject dependencies mocked with Rhino.Mocks
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> : MSTestSpecificationBase<TContract, TSubject, RhinoMocksMockFactory>
        where TSubject : TContract
    {
    }
}