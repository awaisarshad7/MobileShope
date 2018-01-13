using System;
using System.Collections.Generic;

namespace MobileShope.Models
{
    public partial class Items
    {
        public int ItemsId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string ModelN0 { get; set; }
        public string Color { get; set; }
    }
}
