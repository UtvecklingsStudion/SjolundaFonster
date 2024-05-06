using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using SjolundaFonster.Data.Models;

namespace SjolundaFonster.Components
{
    partial class ColorCard
    {
        [Parameter]
        public Color? CardColor { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
    }
}
