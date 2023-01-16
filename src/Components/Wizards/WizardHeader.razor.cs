using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorNifty.Components.Wizards
{
    public partial class WizardHeader
    {
        /// <summary>
        /// The Child Content of the current <see cref="WizardStep"/>
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public int ActiveStepIndex { get; set; }
    }
}
