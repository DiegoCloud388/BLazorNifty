using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Layout
{
    public partial class LayoutOverride : IDisposable
    {
        private bool disposedValue;

        [Inject] public ILayoutManagementService LayoutManagementService { get; set; }

        [Parameter] public bool StickyHeader 
        { 
            get { return LayoutManagementService.StickyHeader; } 
            set { LayoutManagementService.StickyHeader = value; } 
        }

        [Parameter] public bool StickyNavigation
        {
            get { return LayoutManagementService.StickyNavigation; }
            set { LayoutManagementService.StickyNavigation = value; }
        }


        protected override void OnInitialized()
        {
           
            base.OnInitialized();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    LayoutManagementService.ResetLayout();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
