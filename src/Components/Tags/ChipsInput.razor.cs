using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace BlazorNifty.Components.Tags
{
    public partial class ChipsInput
    {
        #region Properties

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
        public List<string>? AllowedValues { get; set; } = null;

        /// <summary>
        /// The validation message to use when the chip/tag value is not present in the AllowedValues list
        /// </summary>
        [Parameter]
        public string AllowedValueValidationMessage { get; set; } = "The value is not present in the allowed values list";

        /// <summary>
        /// The css class placed on every chip
        /// </summary>
        [Parameter]
        public string StyleChip { get; set; } = string.Empty;

        /// <summary>
        /// The css class placed on the list tag of the chips
        /// </summary>
        [Parameter]
        public string StyleChipsList { get; set; } = string.Empty;

        /// <summary>
        /// The css class placed on the container of the chips input
        /// </summary>
        [Parameter]
        public string StyleChipsContainer { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether or not backspace will remove the last chip
        /// </summary>
        [Parameter]
        public bool EnableBackspaceRemove { get; set; } = true;

        /// <summary>
        /// Indicates whether or not readonly items can be deleted
        /// </summary>
        [Parameter]
        public bool EnableRemoveButton { get; set; } = true;

        /// <summary>
        /// Indicates whether or not to show validation errors
        /// </summary>
        [Parameter]
        public bool ShowValidationErrors { get; set; } = false;

        /// <summary>
        /// Indicates whether or not empty values are allowed as a value
        /// </summary>
        [Parameter]
        public bool AllowEmptyValue { get; set; } = false;

        /// <summary>
        /// Indicates whether or not duplicate values
        /// </summary>
        [Parameter]
        public bool AllowDuplicateValues { get; set; } = false;

        /// <summary>
        /// The validation message to use when the AllowEmptyValue rule is not respected
        /// </summary>
        [Parameter]
        public string AllowEmptyValueValidationMessage { get; set; } = "An empty input is not allowed";

        /// <summary>
        /// The maximum number of chips
        /// </summary>
        [Parameter]
        public int? MaxValueCount { get; set; } = null;

        /// <summary>
        /// The validation message to use when the MaxValueCount rule is not respected
        /// </summary>
        [Parameter]
        public string MaxValueCountValidationMessage { get; set; } = $"The max amount of chip values has been reached";

        /// <summary>
        /// The minimum value length of a chip
        /// </summary>
        [Parameter]
        public int? MinValueLength { get; set; } = null;

        /// <summary>
        /// The validation message to use when the MinValueLength rule is not respected
        /// </summary>
        [Parameter]
        public string MinValueLengthValidationMessage { get; set; } = $"The chip value doesn't meet the min length requirements";

        /// <summary>
        /// The maximum value length of a chip
        /// </summary>
        [Parameter]
        public int? MaxValueLength { get; set; } = null;

        /// <summary>
        /// The validation message to use when the MaxValueLength rule is not respected
        /// </summary>
        [Parameter]
        public string MaxValueLengthValidationMessage { get; set; } = $"The chip value exceeds the max length requirements";

        /// <summary>
        /// Indicates whether or not to show the text input outline
        /// </summary>
        [Parameter]
        public bool ShowInputOutline { get; set; } = false;

        /// <summary>
        /// Callback to perform custom validation
        /// </summary>
        [Parameter]
        public EventCallback<ChipValidationArgs> CustomValidation { get; set; }

        /// <summary>
        /// Custom template for prepending an icon to the chip
        /// </summary>
        [Parameter]
        public RenderFragment? PrependIconTemplate { get; set; }

        /// <summary>
        /// Custom template for showing validation errors, make sure to set 'ShowValidationErrors' to true in order for validation errors to render
        /// </summary>
        [Parameter]
        public RenderFragment<string>? ValidationErrorTemplate { get; set; }

        /// <summary>
        /// Custom attributes for the text input
        /// </summary>
        [Parameter]
        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Custom attribute for placeholder
        /// </summary>
        [Parameter]
        public string PlaceholderText { get; set; } = string.Empty;

        /// <summary>
        /// Custom attribute separator 
        /// </summary>
        [Parameter]
        public string Separator { get; set; } = "Enter";

        #endregion

        private string currentInputValue = "";
        private string prevInputValue = "";
        private List<string> validationErrors = new List<string>();

        protected override void OnInitialized()
        {
            if (ReadonlyChips && !InputAttributes.ContainsKey("readonly")) InputAttributes.Add("readonly", "");
        }

        private void OnInput(ChangeEventArgs args)
        {
            prevInputValue = currentInputValue;
            currentInputValue = args.Value.ToString();
        }

        private void OnKeyDown(KeyboardEventArgs args)
        {
            if (currentInputValue.Length == 0 && args.Key == "Backspace")
            {
                prevInputValue = currentInputValue;
            }
        }

        private void OnKeyUp(KeyboardEventArgs args)
        {
            validationErrors.Clear();

            if (EnableBackspaceRemove && args.Key == "Backspace" && Chips.Count > 0 && prevInputValue.Length == 0 && !ReadonlyChips) RemoveChip(Chips.Last());
            if (args.Key != Separator) return;
            if (CustomValidation.HasDelegate) CustomValidation.InvokeAsync(new ChipValidationArgs(Chips, currentInputValue, validationErrors));
            if (string.IsNullOrEmpty(currentInputValue) && !AllowEmptyValue) validationErrors.Add(AllowEmptyValueValidationMessage);
            if (MaxValueCount != null && Chips.Count == MaxValueCount) validationErrors.Add(MaxValueCountValidationMessage);
            if (MaxValueLength != null && currentInputValue.Length > MaxValueLength) validationErrors.Add(MaxValueLengthValidationMessage);
            if (MinValueLength != null && currentInputValue.Length < MinValueLength) validationErrors.Add(MinValueLengthValidationMessage);
            if (AllowedValues != null && AllowedValues.Count > 0 && !AllowedValues.Contains(currentInputValue, StringComparer.OrdinalIgnoreCase)) validationErrors.Add(AllowedValueValidationMessage);
            if (validationErrors.Count > 0) return;
            if (!AllowDuplicateValues && Chips.Contains(currentInputValue, StringComparer.OrdinalIgnoreCase)) return;

            if (Separator.ToCharArray().Length == 1) 
                Chips.Add(prevInputValue);
            else
                Chips.Add(currentInputValue);

            currentInputValue = "";
            OnChipsChanged.InvokeAsync(Chips);
        }

        private void RemoveChip(string chip)
        {
            Chips.Remove(chip);
            OnChipsChanged.InvokeAsync(Chips);
        }
    }
}
