using System.Data;
using System.Net.Mail;

namespace Movies.Backend.Models
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() { Username = "admin", EmailAddress = "jason.admin@email.com", Password = "admin", Role = "Administrator" },
            new User() { Username = "elyse_seller", EmailAddress = "elyse.seller@email.com", Password = "MyPass_w0rd", Role = "Seller" },
        };
    }
}
