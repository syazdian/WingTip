using System;
using System.Collections.Generic;
using System.Text;

namespace WingTipApi.DAL.Entities
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public int Qauntity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
