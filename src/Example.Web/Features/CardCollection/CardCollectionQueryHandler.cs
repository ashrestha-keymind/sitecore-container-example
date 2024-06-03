namespace Example.Web.Features.CardCollection
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Infrastructure.Services.Interfaces;
    using MediatR;
    using Sitecore.Common;
    using Sitecore.Mvc.Presentation;

    public class CardCollectionQuery : IRequest<CardCollectionViewModel>
    {
    }

    public class CardCollectionQueryHandler : IRequestHandler<CardCollectionQuery, CardCollectionViewModel>
    {
        private readonly IMediaService _mediaService;

        public CardCollectionQueryHandler(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public Task<CardCollectionViewModel> Handle(CardCollectionQuery request, CancellationToken cancellationToken)
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;
            var model = new CardCollectionViewModel();

            var cards = renderingItem.Children.Where(x => x.TemplateName == "Card").WhereNotNull();

            foreach (var cardItem in cards)
            {
                var card = new CardViewModel
                {
                    Description = cardItem["Description"],
                    Image = _mediaService.GetImage(cardItem.Fields["Image"])
                };

                model.Cards.Add(card);
            }

            return Task.FromResult(model);
        }
    }
}
