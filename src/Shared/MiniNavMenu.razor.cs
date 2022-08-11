using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Shared
{
    public partial class MiniNavMenu
    {
        private List<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem()
            {
                Title = "Navigation",
                Type = MenuItemType.NavCategory,
                ChildItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Title = "Dashboards",
                        Icon = "bi bi-house-door",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Dashboard 1", Href = "/dashboard-1", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Dashboard 2", Href = "/dashboard-2", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Dashboard 3", Href = "/dashboard-3", Type=MenuItemType.NavItem, Class="ml-4px"}
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Layouts",
                        Icon = "bi bi-columns",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Mini Navigation", Href = "/layouts/minimal-navigation", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Push Navigation", Href = "/layouts/push-navigation", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Slide Navigation", Href = "/layouts/slide-navigation", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Stuck Sidebar", Href = "/layouts/stuck-sidebar", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Pinned Sidebar", Href = "/layouts/pinned-sidebar", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Unite Sidebar", Href = "/layouts/unite-sidebar", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Sticky Header", Href = "/layouts/sticky-header", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Sticky Navigation", Href = "/layouts/sticky-navigation", Type=MenuItemType.NavItem, Class="ml-4px"}
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Widgets",
                        Icon = "bi bi-alarm",
                        Href = "/widgets",
                        Class = "root",
                        Type=MenuItemType.NavItem
                    }
                }
            },
            new MenuItem()
            {
                Title = "Components",
                Type = MenuItemType.NavCategory,
                ChildItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Title = "Ui Elements",
                        Icon = "bi bi-toggles",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Buttons", Href = "/ui-elements/buttons", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Cards", Href = "/ui-elements/cards", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Dropdowns", Href = "/ui-elements/dropdowns", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Typography", Href = "/ui-elements/typography", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "List Group", Href = "/ui-elements/list-group", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Progress", Href = "/ui-elements/progress", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Placeholders", Href = "/ui-elements/placeholders", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Tabs & Accordions", Href = "/ui-elements/tabs-accordions", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Components", Href = "/ui-elements/components", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Tooltips & Popover", Href = "/ui-elements/tooltips-popovers", Type=MenuItemType.NavItem, Class="ml-4px"}
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Forms",
                        Icon = "bi bi-pencil",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "General", Href = "/forms/general", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Tags", Href = "/forms/tags", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Date Time Picker", Href = "/forms/date-time-picker", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Validation", Href = "/forms/validation", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Wizard", Href = "/forms/wizard", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "File Uploads", Href = "/forms/file-uploads", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Text Editor", Href = "/forms/text-editor", Type=MenuItemType.NavItem, Class="ml-4px"}
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Tables",
                        Icon = "bi bi-table",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Static Tables", Href = "/tables/static-tables", Type=MenuItemType.NavItem, Class="ml-4px"},
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Charts",
                        Icon = "bi bi-bar-chart-line",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "MudBlazor Charts", Href = "charts/mud-blazor-charts", Type=MenuItemType.NavItem, Class="ml-4px"},

                        }
                    },
                    new MenuItem()
                    {
                        Title = "Miscellaneous",
                        Icon = "bi bi-tools",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Timeline", Href = "/misc/timeline", Type=MenuItemType.NavItem, Class="ml-4px"},

                        }
                    },
                }

            },
            new MenuItem()
            {
                Title = "More",
                Type = MenuItemType.NavCategory,
                ChildItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Title = "App Views",
                        Icon = "bi bi-cast",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "File Manager", Href = "/app-views/file-manager", Type=MenuItemType.NavItem, Class="ml-4px"},
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Blog Apps",
                        Icon = "bi bi-chat-square",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Blog", Href = "/blog-apps/blog", Type=MenuItemType.NavItem, Class="ml-4px"},
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Email",
                        Icon = "bi bi-envelope",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Inbox", Href = "/email/inbox", Type=MenuItemType.NavItem, Class="ml-4px"},
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Other Pages",
                        Icon = "bi bi-filetype-html",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Blank Page", Href = "/other-pages/blank", Type=MenuItemType.NavItem, Class="ml-4px"},
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Front Pages",
                        Icon = "bi bi-window-fullscreen",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Error 404", Href = "/front-pages/error-404", Type=MenuItemType.NavItem, Class="ml-4px"},
                        }
                    },
                    new MenuItem()
                    {
                        Title = "Menu Levels",
                        Icon = "bi bi-list-nested",
                        Type = MenuItemType.NavGroup,
                        ChildItems = new List<MenuItem>()
                        {
                            new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link1", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link2", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link3", Type=MenuItemType.NavItem, Class="ml-4px"},
                            new MenuItem() {Title = "Submenu 1", Type=MenuItemType.NavGroup,  Class="ml-4px", ChildItems = new List<MenuItem>
                            {
                                new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link4", Type=MenuItemType.NavItem, Class="ml-4px"},
                                new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link5", Type=MenuItemType.NavItem, Class="ml-4px"},
                                new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link6", Type=MenuItemType.NavItem, Class="ml-4px"},
                            }},
                            new MenuItem() {Title = "Submenu 2", Type=MenuItemType.NavGroup,  Class="ml-4px", ChildItems = new List<MenuItem>
                            {
                                new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link7", Type=MenuItemType.NavItem, Class="ml-4px"},
                                new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link8", Type=MenuItemType.NavItem, Class="ml-4px"},
                                new MenuItem() {Title = "Menu Link", Href = "/menu-levels/link9", Type=MenuItemType.NavItem, Class="ml-4px"},
                            }},
                        }
                    },
                }
        }
        };

        [Inject] NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            

            NavigationManager.LocationChanged += NavigationManager_LocationChanged;
            SetActiveItem(NavigationManager.Uri);

            base.OnInitialized();
        }

        private void NavigationManager_LocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            SetActiveItem(e.Location);
        }

        private void SetActiveItem(string location)
        {
            location = location.Replace(NavigationManager.BaseUri, string.Empty);
            location = "/" + location;

            foreach (var item in GetNodes())
            {
                var innerNodes = GetNodes(item);
                if (innerNodes.Any(x => x.Href == location))
                {
                    item.State = "active";
                }
                else
                {
                    item.State = String.Empty;
                }
            }

            StateHasChanged();
        }

        public IEnumerable<MenuItem> GetNodes()
        {
            List<MenuItem> flatMenu = new List<MenuItem>();

            foreach (var item in menuItems)
            {
                flatMenu.AddRange(GetNodes(item));
            }

            return flatMenu;
        }

        public IEnumerable<MenuItem> GetNodes(MenuItem node)
        {
            if (node == null)
            {
                yield break;
            }
            yield return node;
            foreach (var n in node.ChildItems)
            {
                foreach (var innerN in GetNodes(n))
                {
                    yield return innerN;
                }
            }
        }
    }
}
