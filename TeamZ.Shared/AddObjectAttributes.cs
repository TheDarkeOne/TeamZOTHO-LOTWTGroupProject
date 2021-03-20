using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamZ.Shared
{
    public class AddObjectAttributes
    {
        public string Username { get; set; }
        public string SessionKey { get; set; }
        public string Name { get; set; }    // Username or item name
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
