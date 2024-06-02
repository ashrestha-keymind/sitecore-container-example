namespace Example.Web.Infrastructure.Dependencies
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        public static void AddMvcControllers(this IServiceCollection serviceCollection, params Type[] types)
        {
            foreach (var type in types)
            {
                var controllers = type.Assembly.GetExportedTypes()
                    .Where(t => typeof(BaseController).IsAssignableFrom(t)
                                   && !t.IsAbstract
                                   && !t.IsGenericTypeDefinition)
                    .ToArray();

                foreach (var controller in controllers)
                {
                    serviceCollection.AddTransient(controller);
                }
            }
        }
    }
}
