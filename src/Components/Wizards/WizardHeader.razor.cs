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

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
