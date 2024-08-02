namespace Example.Web.Features.Banner.TwoColumn
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Features.Shared.Model;
    using Example.Web.Infrastructure.Services.Interfaces;
    using MediatR;
    using Sitecore.Mvc.Presentation;

    public class TwoColumnQuery : IRequest<TwoColumnViewModel>
    {
    }

    public class TwoColumnQueryHandler : IRequestHandler<TwoColumnQuery, TwoColumnViewModel>
    {
        private readonly IMediaService _mediaService;

        public TwoColumnQueryHandler(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public Task<TwoColumnViewModel> Handle(TwoColumnQuery request, CancellationToken cancellationToken)
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;
            var styleParameter = RenderingContext.Current.Rendering.Parameters["Style"];
            var styleItem = styleParameter != null ? Sitecore.Context.Database.GetItem(styleParameter) : null;

            var model = new TwoColumnViewModel
            {
                Title = renderingItem["Title"],
                Description = renderingItem["Description"],
                Image = _mediaService.GetImage(renderingItem.Fields["Image"]),
                Style = styleItem != null ? styleItem["Value"] : "order-0",
                Links = renderingItem.GetChildren()
                .FirstOrDefault(x => x.TemplateName == "LinkFolder")
                .GetChildren().Where(x => x.TemplateName == "Link")
                .Select(x => new LinkViewModel
                {
                    Label = x["Label"],
                    Href = x["Href"]
                })
            };

            return Task.FromResult(model);
        }
    }
}
