using BlazorNifty.Components.Layout;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorNifty.Shared
{
    public partial class MainLayout
    {
        bool _leftDrawerOpen = true;
        bool _rightDrawerOpen = false;
        bool stickyNavigation = true;
        bool doubleRefresh;
        [Inject] public ILayoutManagementService LayoutManagementService { get; set; }

        string mainContentClass;
        string layoutClass;
        string navigationClass;
        string settingsClass = "settings-offcanvas";
        bool settingsOpen;
        bool firstRender = false;

        MudTheme theme = new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = "#25476a",
                Success = "#9FCC2E",
                Error = "DF5645"
            },
            Typography = new Typography()
            {
                Default = new Default()
                {
                    FontFamily = new[] { "Poppins", "Open Sans", "Segoe UI", "Helvetica Neue", "Noto Sans", "Liberation Sans", "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji" }
                },
                H1 = new H1() { FontSize = "calc(1.3125rem + .75vw)", FontWeight = 500, LineHeight = 1.2 },
                H2 = new H2() { FontSize = "calc(1.275rem + .3vw);", FontWeight = 500, LineHeight = 1.2 },
                H3 = new H3() { FontSize = "calc(1.25625rem + .075vw)", FontWeight = 500, LineHeight = 1.2 },
                H4 = new H4() { FontSize = "1.125rem", FontWeight = 500, LineHeight = 1.2 },
                H5 = new H5() { FontSize = ".9375rem", FontWeight = 500, LineHeight = 1.2 },
                H6 = new H6() { FontSize = ".75rem", FontWeight = 500, LineHeight = 1.2 },
                Body1 = new Body1() { FontSize = ".9375rem", LineHeight = 1.5, FontWeight = 400 },
                Body2 = new Body2() { FontSize = ".835rem", LineHeight = 1.5, FontWeight = 400 }
            },
            LayoutProperties = new LayoutProperties()
            {

                DrawerWidthLeft = "220px",
                DrawerWidthRight = "275px",

            }
        };

        void DrawerToggle()
        {
            _leftDrawerOpen = !_leftDrawerOpen;

            RenderLayout();
        }

        void RightDrawerToggle()
        {
            _rightDrawerOpen = !_rightDrawerOpen;

            StateHasChanged();
        }

        void SettingsToggle()
        {


            settingsOpen = !settingsOpen;

            if (settingsOpen)
            {
                settingsClass = "settings-offcanvas settings-offcanvas-show";
            }
            else
            {
                settingsClass = "settings-offcanvas";
            }


            StateHasChanged();
        }

        protected override void OnInitialized()
        {

            LayoutManagementService.LayoutChanged += (s, e) => RenderLayout();
            base.OnInitialized();


        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                LayoutManagementService.SetDefaultValues(new Dictionary<string, object>()
                {
                    {"StickyHeader", false},
                    {"StickyNavigation", false}

                });

                this.firstRender = firstRender;
                StateHasChanged();
            }

            if (doubleRefresh)
            {
                doubleRefresh = false;  
                StateHasChanged();
            }

            
            base.OnAfterRender(firstRender);
        }

        private void RenderLayout()
        {
            layoutClass = string.Empty;
            mainContentClass = string.Empty;
            navigationClass = string.Empty;

            if (!LayoutManagementService.StickyNavigation)
            {
                navigationClass = "drawer-left-nonsticky";
            }

            if (!LayoutManagementService.StickyHeader)
            {
                mainContentClass += " main-content-appbar-unfixed";
                layoutClass += "layout-nonsticky-header";
            }
            
            if(LayoutManagementService.StickyHeader)
            {
                layoutClass += "layout-sticky-header";
            }

            doubleRefresh = true;
            StateHasChanged();
        }
    }
}
