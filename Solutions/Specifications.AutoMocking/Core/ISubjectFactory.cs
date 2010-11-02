namespace Specifications.AutoMocking.Core
{
    public interface ISubjectFactory
    {
        Contract create<Contract, Class>();
    }
}