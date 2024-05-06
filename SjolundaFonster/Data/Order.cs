using System.ComponentModel.DataAnnotations;

namespace SjolundaFonster.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public List<Window>? Products { get; set; } = new List<Window>();
    }
}
