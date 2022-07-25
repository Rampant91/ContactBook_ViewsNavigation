using System.ComponentModel.DataAnnotations;

namespace ContactBook_ViewsNavigation.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int ContactId { get; set; }

        public string? Name { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public string? Date { get; set; }

        public string? Discription { get; set; }
    }
}
