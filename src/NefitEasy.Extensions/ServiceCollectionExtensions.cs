namespace NefitEasy.Extensions
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddNefitEasy(this IServiceCollection services, Action<NefitEasyOptions> optionsProvider)
        {
            var options = new NefitEasyOptions();
            optionsProvider(options);

            if (options.IsSingletonClient)
                services.AddSingleton(provider => new NefitEasyClientFactory(options).Produce());
            else
                services.AddTransient(provider => new NefitEasyClientFactory(options).Produce());
        }
    }
}