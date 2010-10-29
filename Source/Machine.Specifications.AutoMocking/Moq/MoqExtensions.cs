using System;
using System.Linq.Expressions;
using Moq;

namespace Machine.Specifications.AutoMocking.Moq
{
	public static class MoqExtensions
	{
		static public void was_told_to<T>(this T mock, Expression<Action<T>> action) where T : class
		{
			received(mock, action);
		}

		static public void was_never_told_to<T>(this T mock, Expression<Action<T>> action) where T : class
		{
			never_received(mock, action);
		}

		static public void received<T>(this T mock, Expression<Action<T>> action) where T : class
		{
			Mock.Get(mock).Verify(action, Times.AtLeastOnce());
		}

		static public void never_received<T>(this T mock, Expression<Action<T>> action) where T : class
		{
			Mock.Get(mock).Verify(action, Times.Never());
		}
	}
}