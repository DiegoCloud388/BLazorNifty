using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace BlazorNifty.Components
{
    public partial class LabelSelect<T> : MudSelect<T>
    {
        [Parameter] public bool InlineOrientation { get; set; }

        [Parameter] public AlignItems LabelAlign { get; set; } = AlignItems.Baseline;

        //[Parameter] public Justify StackJustify { get; set; } = Justify.FlexStart;

        [Parameter] public bool ReverseStack { get; set; }

        [Parameter] public bool LightLabel { get; set; } = true;

        [Parameter] public string? StackClass { get; set; }

        [Parameter] public string? LabelClass { get; set; }

        [Parameter] public string? LabelStyle { get; set; }

        [Parameter] public Typo LabelTypo { get; set; } = Typo.subtitle1;

        [Parameter] public string? LabelText { get; set; }

        [Parameter] public int LabelXs { get; set; } = 12;

        [Parameter] public int LabelSm { get; set; } = 6;

        [Parameter] public int LabelMd { get; set; } = 4;

        [Parameter] public int LabelLg { get; set; } = 2;

        [Parameter] public int LabelXl { get; set; } = 1;

        [Parameter] public int LabelXxl { get; set; } = 1;

        [Parameter] public bool ShowTickIfValid { get; set; } = true;

        [Parameter] public Color TickColorIfValid { get; set; } = Color.Success;

        [Parameter] public string? ExtendBaseClassIfValid { get; set; }

        [Parameter] public int SpacingAfterLabel { get; set; } = 0;

        [Parameter] public EditContext MyEditContext { get; set; }

        [Parameter] public string? PropertyName { get; set; }

        private bool IsFieldValid(bool onlyIfModified = true)
        {
            if (PropertyName != null && MyEditContext != null)
            {
                var identifier = MyEditContext.Field(PropertyName);

                if (onlyIfModified)
                {
                    var isModified = MyEditContext.IsModified(identifier);

                    if (!isModified)
                    {
                        return false;
                    }
                }

                return !MyEditContext.GetValidationMessages(identifier).Any();
            }

            return true;
        }

        private string GetMarginOffsetForShrink()
        {
            string marginClass;

            if (Adornment == Adornment.End)
            {
                if (Clearable == true)
                {
                    marginClass = "mr-15";
                }
                else
                {
                    marginClass = "mr-9";
                }
            }
            else
            {
                if (Clearable == true)
                {
                    marginClass = "mr-9";
                }
                else
                {
                    marginClass = "mr-3";
                }
            }

            return $"{marginClass} d-flex flex-row shrink-select align-self-stretch";
        }
    }
}
