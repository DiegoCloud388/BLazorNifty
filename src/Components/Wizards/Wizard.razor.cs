﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Windows.Input;

namespace BlazorNifty.Components.Wizards
{
    public partial class Wizard
    {
        /// <summary>
        /// 
        /// </summary>
        protected internal List<WizardStep> Steps = new List<WizardStep>();

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter] public string? Width { get; set; }

        /// <summary>
        /// The Active <see cref="WizardStep"/>
        /// </summary>
        [Parameter]
        public WizardStep? ActiveStep { get; set; }

        /// <summary>
        /// The Index number of the <see cref="ActiveStep"/>
        /// </summary>
        [Parameter]
        public int ActiveStepIndex { get; set; }

        /// <summary>
        /// Next button title
        /// </summary>
        [Parameter]
        public string NextButtonTitle { get; set; } = "Next";

        /// <summary>
        /// Back button title
        /// </summary>
        [Parameter]
        public string BackButtonTitle { get; set; } = "Previous";

        /// <summary>
        /// Submit button title
        /// </summary>
        [Parameter]
        public string SubmitButtonTitle { get; set; } = "Submit";

        /// <summary>
        /// If you want disable back button on finish step set on false.
        /// </summary>
        [Parameter]
        public bool IsBackOnFinishEnabled { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback OnSubmit { get; set; }

        /// <summary>
        /// Gets or sets the command to be executed when clicked on a button.
        /// </summary>
        [Parameter] 
        public ICommand SubmitCommand { get; set; }

        /// <summary>
        /// Reflects the parameter to pass to the CommandProperty upon execution.
        /// </summary>
        [Parameter] 
        public object SubmitCommandParameter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback OnValidSubmit { get; set; }

        /// <summary>
        /// Determines whether the Wizard is in the last step
        /// </summary>
        public bool IsLastStep { get; set; }

        /// <summary>
        /// Determines whether the back button is enabled.
        /// </summary>
        public bool IsBackButtonEnabled { get; set; }

        public int StepsIndex(WizardStep step) => StepsIndexInternal(step);

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                if (Steps.Count != 0)
                {
                    SetActive(Steps[0]);
                    StateHasChanged();
                }
            }
        }

        protected internal void AddStep(WizardStep step)
        {
            Steps.Add(step);
        }

        private int StepsIndexInternal(WizardStep step)
        {
            if (step == null)
                throw new ArgumentNullException(nameof(step));

            return Steps.IndexOf(step);
        }

        private void SetActive(WizardStep step)
        {
            ActiveStep = step ?? throw new ArgumentNullException(nameof(step));

            ActiveStepIndex = StepsIndex(step);

            if (ActiveStepIndex == Steps.Count - 1)
            {
                IsLastStep = true;

                if(!IsBackOnFinishEnabled)                
                    IsBackButtonEnabled = false;                
            }
                
            else
            {
                IsLastStep = false;
                IsBackButtonEnabled = true;
            }
        }

        private void GoBack()
        {
            if (ActiveStepIndex > 0)
                SetActive(Steps[ActiveStepIndex - 1]);
        }

        private void GoNext()
        {
            if (ActiveStep != null)
            {
                if (ActiveStep.ValidateStep)
                {
                    bool isValid = ActiveStep.StepHandleValidSubmit();

                    if (isValid)
                    {
                        if (ActiveStepIndex < Steps.Count - 1)
                            SetActive(Steps[ActiveStepIndex + 1]);
                    }
                }
                else
                {
                    if (ActiveStepIndex < Steps.Count - 1)
                        SetActive(Steps[ActiveStepIndex + 1]);
                }
            }
        }

        protected async Task SubmitHandler()
        {
            await OnSubmit.InvokeAsync(null);

            if (SubmitCommand?.CanExecute(SubmitCommandParameter) ?? false)
            {
                SubmitCommand.Execute(SubmitCommandParameter);
            }
        }

    }
}
