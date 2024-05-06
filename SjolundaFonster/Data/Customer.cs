using System.ComponentModel.DataAnnotations;

namespace SjolundaFonster.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public int? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<Order>? Orders { get; set; } = new List<Order>();

    }
}
