using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeChatApp.Models
{
    public class user
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
    }
}
