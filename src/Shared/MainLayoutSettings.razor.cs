using BlazorNifty.Components.Layout;
using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Shared
{
    public partial class MainLayoutSettings
    {
        [Inject] public ILayoutManagementService? LayoutManagementService { get; set; }
    }
}
