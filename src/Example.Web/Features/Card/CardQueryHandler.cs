namespace Example.Web.Features.Card
{
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Infrastructure.Services.Interfaces;
    using MediatR;
    using Sitecore.Mvc.Presentation;

    public class CardQuery : IRequest<CardViewModel>
    {
    }

    public class CardQueryHandler : IRequestHandler<CardQuery, CardViewModel>
    {
        private readonly IMediaService _mediaService;

        public CardQueryHandler(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public Task<CardViewModel> Handle(CardQuery request, CancellationToken cancellationToken)
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;

            var model = new CardViewModel
            {
                Description = renderingItem["Description"],
                Image = _mediaService.GetImage(renderingItem.Fields["Image"])
            };

            return Task.FromResult(model);
        }
    }
}
