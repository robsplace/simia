using System;

namespace Simia.Entities
{
    [Serializable()]
    public class User
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool Paid { get; set; }
    }
}
