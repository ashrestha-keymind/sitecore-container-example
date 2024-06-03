namespace Example.Web.Features.CardCollection
{
    using System.Collections.Generic;

    public class CardCollectionViewModel
    {
        public IList<CardViewModel> Cards { get; set; } = new List<CardViewModel>();
    }
}
