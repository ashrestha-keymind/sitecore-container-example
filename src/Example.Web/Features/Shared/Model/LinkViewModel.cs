namespace Example.Web.Features.Shared.Model
{
    using Sitecore.Data.Fields;

    public class LinkViewModel
    {
        public string Label { get; set; }

        public LinkField Link { get; set; }

        public string Href
        {
            get
            {
                if (Link == null)
                {
                    return string.Empty;
                }

                if (Link.IsInternal)
                {
                    return Link.GetFriendlyUrl();
                }

                return Link.Url;
            }
        }

        public string Target => Link != null ? Link.Target : string.Empty;
    }
}
