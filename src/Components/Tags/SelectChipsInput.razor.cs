using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace BlazorNifty.Components.Tags
{
    public partial class SelectChipsInput
    {
        /// <summary>
        /// The css class placed on the container of the chips input
        /// </summary>
        [Parameter]
        public string StyleChipsContainer { get; set; } = string.Empty;

        /// <summary>
        /// The css class placed on the list tag of the chips
        /// </summary>
        [Parameter]
        public string StyleChipsList { get; set; } = string.Empty;

        /// <summary>
        /// The css class placed on every chip
        /// </summary>
        [Parameter]
        public string StyleChip { get; set; } = string.Empty;

        /// <summary>
        /// The list of the "applied" chips
        /// </summary>
        [Parameter]
        public List<string> Chips { get; set; } = new List<string>();

        /// <summary>
        /// The callback when the chips list has changed
        /// </summary>
        [Parameter]
        public EventCallback<List<string>> OnChipsChanged { get; set; }

        /// <summary>
        /// Indicates whether or not chips are readonly
        /// </summary>
        [Parameter]
        public bool ReadonlyChips { get; set; } = false;

        /// <summary>
        /// A list of allowed chip/tag values
        /// </summary>
        [Parameter]
        public List<string> AllowedValues { get; set; } = new List<string>();

        /// <summary>
        /// Indicates whether or not readonly items can be deleted
        /// </summary>
        [Parameter]
        public bool EnableRemoveButton { get; set; } = true;

        /// <summary>
        /// Custom template for prepending an icon to the chip
        /// </summary>
        [Parameter]
        public RenderFragment? PrependIconTemplate { get; set; }

        /// <summary>
        /// Custom attributes for the text input
        /// </summary>
        [Parameter]
        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();


        private MudAutocomplete<string> autocomplete;

        protected override void OnInitialized()
        {
            if (ReadonlyChips && !InputAttributes.ContainsKey("readonly")) InputAttributes.Add("readonly", "");
        }

        private void RemoveChip(string chip)
        {
            Chips.Remove(chip);
            OnChipsChanged.InvokeAsync(Chips);
        }

        private void SelectedValue(string selectedChip)
        {
            Chips.Add(selectedChip);
           
            autocomplete.Clear();
        }

        private async Task<IEnumerable<string>> Search(string value)
        {
            await Task.Delay(5);

            if (string.IsNullOrEmpty(value))
                return AllowedValues;

            return AllowedValues.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
