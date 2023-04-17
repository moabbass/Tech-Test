namespace Verto.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public List<Detail> Details { get; set; }
        public List<Product> products { get; set; }
        public List<SpecialOffer> specialOffers { get; set; }

        public Collection()
        {

        }


    }
}
