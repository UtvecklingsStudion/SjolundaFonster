using System.ComponentModel.DataAnnotations;

namespace SjolundaFonster.Data.Models
{
    public class Window
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Width is required.")]
        [Range(500, 1500, ErrorMessage = "Välj en bredd mellan 500-1500mm.")]
        public int Width { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        [Range(500, 1500, ErrorMessage = "Välj en höjd mellan 500-1500mm.")]
        public int Height { get; set; }

        public Model Model { get; set; }
        public Color Color { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
