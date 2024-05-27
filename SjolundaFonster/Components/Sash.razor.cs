using Microsoft.AspNetCore.Components;

namespace SjolundaFonster.Components
{
    partial class Sash
    {
        [Parameter] public int ModelId { get; set; }
        [Parameter] public bool HingeLeft { get; set; }
        [Parameter] public bool HingeRight { get; set; }
        private string GetWindowSashModel()
        {
            switch (ModelId)
            {
                case 1:
                    return "window-sash-model1";
                case 2:
                    return "window-sash-model2";
                default:
                    return "window-sash-model3";
            }
        }
        private string GetHingeTopPosition()
        {
            switch (true)
            {
                case var _ when HingeLeft:
                    return "sash-hinge-left-top";
                case var _ when HingeRight:
                    return "sash-hinge-right-top";
                default:
                    return "";
            }
        }
        private string GetHingeBottomPosition()
        {
            switch (true)
            {
                case var _ when HingeLeft:
                    return "sash-hinge-left-bottom";
                case var _ when HingeRight:
                    return "sash-hinge-right-bottom";
                default:
                    return "";
            }
        }
    }
}
