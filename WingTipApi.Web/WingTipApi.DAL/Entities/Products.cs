using System;
using System.Collections.Generic;
using System.Text;

namespace WingTipApi.DAL.Entities
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public int  CategoryID { get; set; }
    }
}
