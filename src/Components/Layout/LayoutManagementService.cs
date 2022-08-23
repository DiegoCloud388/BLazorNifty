using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorNifty.Components.Layout
{
    public interface ILayoutManagementService
    {
        event EventHandler? LayoutChanged;

        public bool StickyHeader { get; set; }
        public bool StickyNavigation { get; set; }
        public bool WidgetProfile { get; set; }
        public bool NavigationCollapsedMode { get; set; }
        public bool NavigationExpandedMode { get; set; }
        public bool NavigationTemporaryMode { get; set; }
        public bool NavigationResponsiveMode { get; set; }
        DrawerVariant NavigationVariant { get; }
        DrawerClipMode NavigationClipMode { get; }
        public void ResetLayout();
        void SetDefaultValues(Dictionary<string, object> defaultValues);
    }

    public class LayoutManagementService : ILayoutManagementService
    {
        private Dictionary<string, object> DefaultValues;
        private Dictionary<string, object> CurrentValues;

        public event EventHandler? LayoutChanged;

        public bool StickyHeader 
        { 
            get { return (bool)CurrentValues[nameof(StickyHeader)]; }        
            set { SetCurrentValue(nameof(StickyHeader), value); } 
        }

        public bool StickyNavigation
        {
            get { return (bool)CurrentValues[nameof(StickyNavigation)]; }
            set { SetCurrentValue(nameof(StickyNavigation), value); }
        }

        public bool WidgetProfile
        {
            get { return (bool)CurrentValues[nameof(WidgetProfile)]; }
            set { SetCurrentValue(nameof(WidgetProfile), value); }
        }

        public bool NavigationCollapsedMode
        {
            get { return (bool)CurrentValues[nameof(NavigationCollapsedMode)]; }
            set 
            {
                SetCurrentValue(nameof(NavigationResponsiveMode), false);
                SetCurrentValue(nameof(NavigationTemporaryMode), false);
                SetCurrentValue(nameof(NavigationExpandedMode), false);
                SetCurrentValue(nameof(NavigationCollapsedMode), true);
            }
        }

        public bool NavigationExpandedMode
        {
            get { return (bool)CurrentValues[nameof(NavigationExpandedMode)]; }
            set 
            {
                SetCurrentValue(nameof(NavigationResponsiveMode), false);
                SetCurrentValue(nameof(NavigationTemporaryMode), false);
                SetCurrentValue(nameof(NavigationExpandedMode), true);
                SetCurrentValue(nameof(NavigationCollapsedMode), false);
            }
        }

        public bool NavigationTemporaryMode
        {
            get { return (bool)CurrentValues[nameof(NavigationTemporaryMode)]; }
            set 
            {
                SetCurrentValue(nameof(NavigationResponsiveMode), false);
                SetCurrentValue(nameof(NavigationTemporaryMode), true);
                SetCurrentValue(nameof(NavigationExpandedMode), false);
                SetCurrentValue(nameof(NavigationCollapsedMode), false);
            }
        }

        public bool NavigationResponsiveMode
        {
            get { return (bool)CurrentValues[nameof(NavigationResponsiveMode)]; }
            set 
            {
                SetCurrentValue(nameof(NavigationResponsiveMode), true);
                SetCurrentValue(nameof(NavigationTemporaryMode), false);
                SetCurrentValue(nameof(NavigationExpandedMode), false);
                SetCurrentValue(nameof(NavigationCollapsedMode), false);
            }
        }


        public DrawerVariant NavigationVariant
        {
            get 
            {
                if (NavigationResponsiveMode)
                {
                    return DrawerVariant.Responsive;
                } 
                else if (NavigationTemporaryMode)
                {
                    return DrawerVariant.Temporary;
                }
                else
                {
                    return DrawerVariant.Mini;
                }
            }
        }

        public DrawerClipMode NavigationClipMode
        {
            get
            {
                if (NavigationTemporaryMode)
                {
                    return DrawerClipMode.Never;
                }
                else
                {
                    return DrawerClipMode.Always;
                }
            }
        }

        public LayoutManagementService()
        {
            DefaultValues = new Dictionary<string, object>()
            {
                { nameof(StickyHeader), true },
                { nameof(StickyNavigation), true },
                { nameof(WidgetProfile), true },
                { nameof(NavigationCollapsedMode), false },
                { nameof(NavigationExpandedMode), true },
                { nameof(NavigationTemporaryMode), false },
                { nameof(NavigationResponsiveMode), false },
            };

            CurrentValues = DefaultValues.ToDictionary(entry => entry.Key, entry => entry.Value);  
        }

        private void SetCurrentValue(string name, object value)
        {
            CurrentValues[name] = value;
            LayoutChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ResetLayout()
        {
            CurrentValues = DefaultValues.ToDictionary(entry => entry.Key, entry => entry.Value);
            LayoutChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SetDefaultValues(Dictionary<string, object> defaultValues)
        {
            foreach (var item in defaultValues)
            {
                DefaultValues[item.Key] = item.Value;
            }

            ResetLayout();
        }
    }
}
