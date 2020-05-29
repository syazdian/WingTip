using System;
using System.Collections.Generic;
using System.Text;

namespace WingTipApi.DAL.Entities
{
    public class CartItems
    {
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }

    }
}
