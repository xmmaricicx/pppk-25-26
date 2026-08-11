using Pppk.WebApi.Models;

namespace Pppk.WebApi.UserExtensions
{
    public static class AddressExtensions
    {
        public static string ToFormatedString(this Address a)
            => $"{a.Street}: {a.HouseNumber}, {a.Post.PostalCode} {a.Post.City}";

    }
}
