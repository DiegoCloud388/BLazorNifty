using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Wizards
{
    public partial class WizardSteps
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
