using Microsoft.AspNetCore.Components;

namespace SjolundaFonster.Components
{
    partial class Accordion
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool IsExpanded { get; set; } = false;


        private void ToggleAccordion()
        {
            IsExpanded = !IsExpanded;
        }
    }
}
