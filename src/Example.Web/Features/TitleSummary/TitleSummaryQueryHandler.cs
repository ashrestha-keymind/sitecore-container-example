namespace Example.Web.Features.TitleSummary
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    public class TitleSummaryQuery : IRequest<TitleSummaryViewModel>
    {
        public Item RenderingItem => RenderingContext.Current.Rendering.Item;
    }

    public class TitleSummaryQueryHandler : IRequestHandler<TitleSummaryQuery, TitleSummaryViewModel>
    {
        public Task<TitleSummaryViewModel> Handle(TitleSummaryQuery request, CancellationToken cancellationToken)
        {
            var model = new TitleSummaryViewModel { Item = request.RenderingItem };

            return Task.FromResult(model);
        }
    }
}
