using Machine.Specifications.AutoMocking.Core;
using System;
using Moq;

namespace Machine.Specifications.AutoMocking.Moq
{
    using System.Reflection;

    public class MoqMocksMockFactory : IMockFactory
    {
        #region MockFactory Members

        public Dependency create_stub<Dependency>() where Dependency : class
        {
            return new Mock<Dependency>().Object;
        }

        public object create_stub(Type type)
        {
            var genericType = typeof(Mock<>).MakeGenericType(new[] { type });
            object mock = Activator.CreateInstance(genericType);
            PropertyInfo objectProperty = mock.GetType().GetProperty(
                "Object", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            return objectProperty.GetValue(mock, null);
        }
        #endregion
    }
}