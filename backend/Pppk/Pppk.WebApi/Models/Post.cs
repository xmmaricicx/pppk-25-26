namespace Pppk.WebApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
