using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.MyWizards
{
    public partial class MyWizardSteps
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
