﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BlazorNifty.Components
{
    public partial class LabelTextField<T> : MudTextField<T>
    {
        [Parameter] public bool InlineOrientation { get; set; }

        [Parameter] public AlignItems LabelAlign { get; set; } = AlignItems.Baseline;

        [Parameter] public bool ReverseStack { get; set; }

        [Parameter] public bool LightLabel { get; set; } = true;

        [Parameter] public string? StackClass { get; set; }

        [Parameter] public string? LabelClass { get; set; }

        [Parameter] public string? LabelStyle { get; set; }

        [Parameter] public Typo LabelTypo { get; set; } = Typo.subtitle1;

        [Parameter] public string? LabelText { get; set; }

        [Parameter] public bool ShowTickIfValid { get; set; } = true;

        [Parameter] public Color TickColorIfValid { get; set; } = Color.Success;

        [Parameter] public string? ExtendBaseClassIfValid  { get; set; }

        [Parameter] public int SpacingAfterLabel { get; set; } = 0;     

        [Parameter] public EditContext MyEditContext { get; set; }

        [Parameter] public string? PropertyName { get; set; }

        [Parameter] public string? FixedLabelWidth { get; set; }

        //private Adornment GetAdornmentIfFieldIsValid(bool onlyIfModified = true)
        //{
        //    if (IsFieldValid(onlyIfModified))
        //    {
        //        return Adornment.End;
        //    }

        //    return Adornment.None;

        //}

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

        //private int GetBreakPoint(int labelBreakPoint)
        //{
        //    if (FixedLabelWidth || labelBreakPoint == 12)
        //        return 12;

        //    return 12 - labelBreakPoint;
        //}
    }
}
