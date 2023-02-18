using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Wizards
{
    public partial class WizardHeader
    {
        [CascadingParameter]
        public Wizard Parent { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
