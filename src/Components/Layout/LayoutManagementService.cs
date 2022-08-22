using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Layout
{
    public interface ILayoutManagementService
    {
        event EventHandler? LayoutChanged;

        public bool StickyHeader { get; set; }

        public bool StickyNavigation { get; set; }

        public bool WidgetProfile { get; set; }

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

        public LayoutManagementService()
        {
            DefaultValues = new Dictionary<string, object>()
            {
                { nameof(StickyHeader), true },
                { nameof(StickyNavigation), true },
                { nameof(WidgetProfile), true },
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
