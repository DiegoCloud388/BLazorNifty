﻿using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Wizards
{
    public partial class Wizard<TModel>
    {
        /// <summary>
        /// List of <see cref="WizardStep" /> added to the Wizard
        /// </summary>
        protected internal List<WizardStep<TModel>> Steps = new List<WizardStep<TModel>>();

        /// <summary>
        /// The ChildContent container for <see cref="WizardStep"/>
        /// </summary>
        [Parameter]
        public RenderFragment<TModel> ChildContent { get; set; }

        /// <summary>
        /// The Active <see cref="WizardStep"/>
        /// </summary>
        [Parameter]
        public WizardStep<TModel> ActiveStep { get; set; }

        /// <summary>
        /// The Index number of the <see cref="ActiveStep"/>
        /// </summary>
        [Parameter]
        public int ActiveStepIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public TModel Model { get; set; }

        /// <summary>
        /// Determines whether the Wizard is in the last step
        /// </summary>
        public bool IsLastStep { get; set; }

        /// <summary>
        /// Retrieves the index of the current <see cref="WizardStep"/> in the Step List
        /// </summary>
        /// <param name="step">The WizardStep</param>
        /// <returns></returns>
        public int StepsIndex(WizardStep<TModel> step) => StepsIndexInternal(step);

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SetActive(Steps[0]);
                StateHasChanged();
            }
        }

        private void GoBack()
        {
            if (ActiveStepIndex > 0)
                SetActive(Steps[ActiveStepIndex - 1]);
        }

        private void GoNext()
        {
            if(ActiveStepIndex < Steps.Count - 1)
                SetActive(Steps[ActiveStepIndex + 1]);
        }

        private void GoSubmit()
        {

        }

        private void SetActive(WizardStep<TModel> step)
        {
            ActiveStep = step ?? throw new ArgumentNullException(nameof(step));

            ActiveStepIndex = StepsIndex(step);

            if (ActiveStepIndex == Steps.Count - 1)
                IsLastStep = true;
            else
                IsLastStep = false;
        }

        private int StepsIndexInternal(WizardStep<TModel> step)
        {
            if (step == null)
                throw new ArgumentNullException(nameof(step));

            return Steps.IndexOf(step);
        }

        /// <summary>
        /// Adds a <see cref="WizardStep"/> to the WizardStep list
        /// </summary>
        /// <param name="step"></param>
        protected internal void AddStep(WizardStep<TModel> step)
        {
            Steps.Add(step);
        }
    }
}
