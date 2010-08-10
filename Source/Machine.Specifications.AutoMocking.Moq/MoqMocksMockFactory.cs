using Machine.Specifications.AutoMocking.Core;
using System;
using Moq;

namespace Machine.Specifications.AutoMocking.Moq
{

    public class MoqMocksMockFactory : IMockFactory
    {
        #region MockFactory Members

        public Dependency create_stub<Dependency>() where Dependency : class
        {
            return new Mock<Dependency>().Object;
        }

        public object create_stub(Type type)
        {
            return Mock.Get(type);
        }

        #endregion
    }
}