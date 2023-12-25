using System.ComponentModel.DataAnnotations.Schema;

namespace Webshop.Models
{
    public class ShoppingCar
    {
        public int ShoppingCarId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

