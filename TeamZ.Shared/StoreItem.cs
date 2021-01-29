﻿using System;
using System.Collections.Generic;

namespace TeamZ.Shared
{
    public class StoreItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public List<Category> Categories { get; set; }
    }
}
