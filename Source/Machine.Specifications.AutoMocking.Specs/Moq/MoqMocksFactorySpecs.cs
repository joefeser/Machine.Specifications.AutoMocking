

namespace Machine.Specifications.AutoMocking.Specs.Moq
{


    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;    

    using Machine.Specifications.AutoMocking.Moq;

    #endregion

    [Subject(typeof(MoqMocksMockFactory))]
    public class context_for_moqmocksmockfactory
    {
        protected static MoqMocksMockFactory subject;
        protected static IDbConnection result;

        Establish context = () => subject = new MoqMocksMockFactory();
    }

    [Subject(typeof(MoqMocksMockFactory))]
    public class when_asked_for_a_stub_using_generics : context_for_moqmocksmockfactory
    {
        Because of = () => result = subject.create_stub<IDbConnection>();

        It should_return_the_stub = () => result.ShouldBeOfType(typeof(IDbConnection));
    }


    [Subject(typeof(MoqMocksMockFactory))]
    public class when_asked_for_a_stub_using_type_parameters : context_for_moqmocksmockfactory
    {
        Because of = () => result = (IDbConnection)subject.create_stub(typeof(IDbConnection));

        It should_return_the_stub = () => result.ShouldBeOfType(typeof(IDbConnection));
    }
}
