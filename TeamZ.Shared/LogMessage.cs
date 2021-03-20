using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamZ.Shared
{
    public class LogMessage
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Level { get; set; }
        public string Parameters { get; set; }
        public string Action { get; set; }
    }
}
