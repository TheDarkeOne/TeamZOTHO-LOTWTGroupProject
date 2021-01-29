using System;
using System.Collections.Generic;
using System.Text;

namespace TeamZ.Shared
{
    public class ItemCategory
    {
        public int Id;
        public StoreItem Item { get; set; }
        public int ItemId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
