using Example.Web.Infrastructure.Services;
using Example.Web.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using Sitecore.DependencyInjection;

namespace Example.Web.Infrastructure.Dependencies
{
    public class ServiceConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ServiceConfigurator).Assembly);
            serviceCollection.AddTransient<IMediaService, MediaService>();
        }
    }
}
