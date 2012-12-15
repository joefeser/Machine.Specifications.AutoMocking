using Moq;
namespace Specifications.AutoMocking.Moq
{
	public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
	{
	}

	public abstract class Specification<TContract, TSubject> :
		Specification<TContract, TSubject, MoqMocksMockFactory> where TSubject : TContract
	{
        public virtual Mock<T> MockDependencyOf<T>() where T: class
        {
            return Mock.Get<T>(DependencyOf<T>());
        }
	}
}