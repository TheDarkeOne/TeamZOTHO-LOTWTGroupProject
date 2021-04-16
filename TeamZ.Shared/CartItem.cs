using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZ.Shared
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string SessionKey { get; set; }
        public StoreItem Item { get; set; }

    }
}
