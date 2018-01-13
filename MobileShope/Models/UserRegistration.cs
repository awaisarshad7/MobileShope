using System;
using System.Collections.Generic;

namespace MobileShope.Models
{
    public partial class UserRegistration
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Roll { get; set; }
    }
}
