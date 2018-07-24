
namespace Entities.Account
{
    using Entities.Deals;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<Deal> MyDeals { get; set; }

        public ICollection<Log> MyLogs { get; set; }
    }
}
