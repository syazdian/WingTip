using System;
using System.Collections.Generic;
using System.Text;

namespace WingTipApi.Common
{ 
   public class ProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
    }



}
