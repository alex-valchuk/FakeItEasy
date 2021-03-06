namespace FakeItEasy.Configuration
{
    using System.Reflection;
    using System.Text;
    using FakeItEasy.Creation;

    internal class DefaultInterceptionAsserter
        : IInterceptionAsserter
    {
        private readonly IMethodInterceptionValidator methodInterceptionValidator;

        public DefaultInterceptionAsserter(IMethodInterceptionValidator methodInterceptionValidator)
        {
            this.methodInterceptionValidator = methodInterceptionValidator;
        }

        public void AssertThatMethodCanBeInterceptedOnInstance(MethodInfo method, object? callTarget)
        {
            if (!this.methodInterceptionValidator.MethodCanBeInterceptedOnInstance(method, callTarget, out string? failReason))
            {
                string memberType = method.IsPropertyGetterOrSetter() ? "property" : "method";
                string description = method.GetDescription();
                throw new FakeConfigurationException(ExceptionMessages.CannotInterceptMember(failReason, memberType, description));
            }
        }
    }
}
