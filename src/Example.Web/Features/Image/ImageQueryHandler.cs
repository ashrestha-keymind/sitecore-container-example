namespace Example.Web.Features.Image
{
    using System.Threading;
    using System.Threading.Tasks;
    using Example.Web.Features.Shared.Model;
    using Example.Web.Infrastructure.Services.Interfaces;
    using MediatR;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    public class ImageQuery : IRequest<ImageViewModel>
    {
        public Item RenderingItem => RenderingContext.Current.Rendering.Item;
    }

    public class ImageQueryHandler : IRequestHandler<ImageQuery, ImageViewModel>
    {
        private readonly IMediaService _mediaService;

        public ImageQueryHandler(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public Task<ImageViewModel> Handle(ImageQuery request, CancellationToken cancellationToken)
        {
            var model = _mediaService.GetImage(request.RenderingItem.Fields["Image"]);

            return Task.FromResult(model);
        }
    }
}
