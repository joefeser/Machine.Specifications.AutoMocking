namespace Specifications.AutoMocking.Moq
{
    using System.Reflection;

    using Specifications.AutoMocking.Core;

    using System;

    using global::Moq;

    public class MoqMocksMockFactory : IMockFactory
    {
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
    }
}
