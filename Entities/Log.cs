using Entities.Account;
using System;

namespace Entities
{
    public class Log
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public string ConctrollerName { get; set; }

        public string  ActionName { get; set; }

        public string Act { get; set; }
    }
}
