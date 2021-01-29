using System;
using System.Collections.Generic;
using System.Text;

namespace TeamZ.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<StoreItem> StoreItems { get; set; }
    }
}
