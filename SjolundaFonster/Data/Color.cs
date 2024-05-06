using System.ComponentModel.DataAnnotations;

namespace SjolundaFonster.Data.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string NCS { get; set; }
        public List<Window>? Products { get; set; } = new List<Window>();
    }
}
