using System.ComponentModel.DataAnnotations;

namespace SjolundaFonster.Data.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public List<Window>? Products { get; set; } = new List<Window>();

    }
}
