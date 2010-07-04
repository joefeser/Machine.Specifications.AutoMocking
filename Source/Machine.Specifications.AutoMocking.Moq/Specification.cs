namespace Machine.Specifications.AutoMocking.Moq
{
    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }

    public abstract class Specification<TContract, TSubject> :
        Specification<TContract, TSubject, MoqMocksMockFactory> where TSubject : TContract
    {
    }
}