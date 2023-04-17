using NuGet.DependencyResolver;

namespace Verto.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public List<Detail> details { get; set; }
        public List<Product> products { get; set; }
        public List<SpecialOffer> specialOffers { get; set; }

        public ViewModel()
        {
            details = new List<Detail>();
            products= new List<Product>();
            specialOffers= new List<SpecialOffer>();
        }
    }
}
