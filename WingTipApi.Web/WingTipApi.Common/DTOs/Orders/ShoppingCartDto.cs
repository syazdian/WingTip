using System.Collections.Generic;

namespace WingTipApi.Common.DTOs
{
    public class ShoppingCartDto
    {
        public List<ShoppingCartProductRow> Products { get; set; }
        public string CartId { get; set; }

    }
    public class ShoppingCartInsertDto
    {
        public string CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class ShoppingCartProductRow 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }

}
