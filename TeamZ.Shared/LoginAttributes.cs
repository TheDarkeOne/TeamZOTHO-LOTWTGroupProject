using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamZ.Shared
{
    public class LoginAttributes
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LoginTime { get; set; }
        public string SessionKey { get; set; }
    }
}
