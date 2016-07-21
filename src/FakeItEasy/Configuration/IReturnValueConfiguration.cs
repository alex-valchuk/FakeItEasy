namespace FakeItEasy.Configuration
{
    using System;
    using FakeItEasy.Core;

    /// <summary>
    /// Configures a call that returns a value.
    /// </summary>
    /// <typeparam name="TMember">The type of the member.</typeparam>
    public interface IReturnValueConfiguration<TMember>
        : IExceptionThrowerConfiguration<IReturnValueConfiguration<TMember>>,
          ICallbackConfiguration<IReturnValueConfiguration<TMember>>,
          IAssertConfiguration,
          ICallBaseConfiguration<IReturnValueConfiguration<TMember>>
    {
        /// <summary>
        /// Specifies a function used to produce a return value when the configured call is made.
        /// The function will be called each time this call is made and can return different values
        /// each time.
        /// </summary>
        /// <param name="valueProducer">A function that produces the return value.</param>
        /// <returns>A configuration object.</returns>
        IAfterCallSpecifiedWithOutAndRefParametersConfiguration<IReturnValueConfiguration<TMember>>  ReturnsLazily(Func<IFakeObjectCall, TMember> valueProducer);
    }
}
