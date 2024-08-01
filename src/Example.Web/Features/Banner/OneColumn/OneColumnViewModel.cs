namespace Example.Web.Features.Banner.OneColumn
{
    using System.Collections.Generic;
    using Example.Web.Features.Shared.Model;

    public class OneColumnViewModel : BaseBannerViewModel
    {
        public IEnumerable<LinkViewModel> Links { get; set; } = new List<LinkViewModel>();
    }
}
