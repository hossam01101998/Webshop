namespace Webshop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        [Column(TypeName = "decimal(18, 2)")]   
        public decimal Price { get; set; }

        public List<ShoppingCar> ShoppingCarItems { get; set; }
    }
}
