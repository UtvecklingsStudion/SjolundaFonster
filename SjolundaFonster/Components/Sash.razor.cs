using Microsoft.AspNetCore.Components;

namespace SjolundaFonster.Components
{
    partial class Sash
    {
        [Parameter] public int ModelId { get; set; }
        [Parameter] public bool HingeLeft { get; set; } = false;
        [Parameter] public bool HingeRight { get; set; } = false;

        private string GetWindowSashModel()
        {
            if (ModelId == 1)
            {
                return "window-sash-model1";
            }
            else if (ModelId == 2)
            {
                return "window-sash-model2";
            }
            else
            {
                return "window-sash-model3";
            }
        }

        private string GetHingeTopPosition()
        {
            if (HingeLeft)
            {
                return "sash-hinge-left-top";
            }
            if (HingeRight)
            {
                return "sash-hinge-right-top";
            }
            else
            {
                return "";
            }
        }

        private string GetHingeBottomPosition()
        {
            if (HingeLeft)
            {
                return "sash-hinge-left-bottom";
            }
            if (HingeRight)
            {
                return "sash-hinge-right-bottom";
            }
            else
            {
                return "";
            }
        }
    }
}
