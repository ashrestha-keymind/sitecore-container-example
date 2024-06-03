namespace Example.Web.Features.Jumbotron
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Sitecore.Mvc.Presentation;

    public class JumbotronQuery : IRequest<JumbotronViewModel>
    {
    }

    public class JumbotronQueryHandler : IRequestHandler<JumbotronQuery, JumbotronViewModel>
    {
        public Task<JumbotronViewModel> Handle(JumbotronQuery request, CancellationToken cancellationToken)
        {
            // Get the current rendering item
            var currentRendering = RenderingContext.Current.Rendering.Item;

            if (currentRendering == null)
            {
                return Task.FromResult<JumbotronViewModel>(null);
            }

            var model = new JumbotronViewModel
            {
                Title = currentRendering["Title"],
                Description = currentRendering["Description"],
                Url = currentRendering["URL"]
            };

            return Task.FromResult(model);
        }
    }
}
