using System;
using System.Collections.Generic;

namespace MobileShope.Models_force
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int PricePerUnit { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
    }
}
