using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.MyWizards
{
    public partial class MyWizardHeader
    {
        [CascadingParameter]
        public MyWizard Parent { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
