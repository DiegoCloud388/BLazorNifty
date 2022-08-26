using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Layout
{
    public partial class PageShell
    {
        [Parameter] public bool Overlapping { get; set; }

        [Parameter] public bool Rounded { get; set; }

        [Parameter] public string? Class { get; set; }

        [Parameter] public string? Style { get; set; }

        [Parameter] public RenderFragment? ShellHeader { get; set; }

        [Parameter] public RenderFragment? ShellBody { get; set; }

        [Parameter] public RenderFragment? ShellFooter { get; set; }

        [Inject] public ILayoutManagementService LayoutManagementService { get; set; }

        private string shellClass = "shell";

        protected override void OnInitialized()
        {
            LayoutManagementService.LayoutChanged += (s, e) => { SetShellClass(); StateHasChanged(); };
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {

            SetShellClass();
            base.OnParametersSet();
        }

        private void SetShellClass()
        {
            shellClass = "shell";

            if (Overlapping)
            {
                shellClass += " overlaping";
            }

            if (Rounded && !(LayoutManagementService.PinnedSidebar && LayoutManagementService.UnitedSidebar))
            {
                shellClass += " rounded";
            }

            if (!string.IsNullOrWhiteSpace(Class))
            {
                shellClass += $" {Class}";
            }
        }
    }
}
