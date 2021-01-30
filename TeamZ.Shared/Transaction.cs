using System;
using System.Collections.Generic;
using System.Text;

namespace TeamZ.Shared
{
    public record Transaction
    {
        public int Id { get; set; }
        public int Quantity { get; init; }
        public StoreItem Item { get; init; }
    }
}
