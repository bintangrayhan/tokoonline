
using System.ComponentModel.DataAnnotations;
namespace TokoOnline.models
{
    public class Order
    {
        public int Id { get; set; }

        public required string Customer_name { get; set; }
       
        public required string Shipping_address { get; set; }
       
        public int Total_price { get; set; }

        public int order_date { get; set; }
       
        public required string Status { get; set; }

    }
}
