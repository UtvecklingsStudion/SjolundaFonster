using Microsoft.AspNetCore.Components;

namespace SjolundaFonster.Components
{
    partial class WindowsConfig
    {
        [Parameter] public int Height { get; set; }
        [Parameter] public int Width { get; set; }
        [Parameter] public string? Color { get; set; }
        [Parameter] public int ModelId { get; set; }

    }
}
