﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Windows.Input;

namespace BlazorNifty.Components.Wizards
{
    public partial class WizardStep
    {
        [CascadingParameter]
        public Wizard Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool ValidateStep { get; set; } = true;

        [Parameter]
        public EditContext? StepEditContext { get; set; }

        [Parameter]
        public EventCallback<EditContext> OnStepEditContext { get; set; }

        protected override void OnInitialized()
        {
            Parent.AddStep(this);
        }

        public bool IsLastStep()
        {
            return Parent.Steps.LastOrDefault() == this;
        }

        public bool IsFirstStep()
        {
            return Parent.Steps.FirstOrDefault() == this;
        }

        public bool IsActiveStep()
        {
            return Parent.ActiveStep == this;
        }

        public bool StepHandleValidSubmit()
        {
            if (StepEditContext != null && StepEditContext.Validate())
                return true;

            else
                return false;
        }

        public void OnStepEditContextSelectedChanged(EditContext selectedContext)
        {
            OnStepEditContext.InvokeAsync(selectedContext);
        }
    }
}
