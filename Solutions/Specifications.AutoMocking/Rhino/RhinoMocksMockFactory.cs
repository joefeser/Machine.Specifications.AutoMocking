namespace Specifications.AutoMocking.Rhino
{
    using System;

    using global::Rhino.Mocks;

    using Specifications.AutoMocking.Core;

    public class RhinoMocksMockFactory : IMockFactory
    {
        public Dependency create_stub<Dependency>() where Dependency : class
        {
            return MockRepository.GenerateStub<Dependency>();
        }

        public object create_stub(Type type)
        {
            return MockRepository.GenerateStub(type);
        }
    }
}