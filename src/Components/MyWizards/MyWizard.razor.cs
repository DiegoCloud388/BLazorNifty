using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Windows.Input;

namespace BlazorNifty.Components.MyWizards
{
    public partial class MyWizard
    {
        /// <summary>
        /// 
        /// </summary>
        protected internal List<MyWizardStep> Steps = new List<MyWizardStep>();

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
        public MyWizardStep? ActiveStep { get; set; }

        /// <summary>
        /// The Index number of the <see cref="ActiveStep"/>
        /// </summary>
        [Parameter]
        public int ActiveStepIndex { get; set; }

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

        public int StepsIndex(MyWizardStep step) => StepsIndexInternal(step);

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

        protected internal void AddStep(MyWizardStep step)
        {
            Steps.Add(step);
        }

        private int StepsIndexInternal(MyWizardStep step)
        {
            if (step == null)
                throw new ArgumentNullException(nameof(step));

            return Steps.IndexOf(step);
        }

        private void SetActive(MyWizardStep step)
        {
            ActiveStep = step ?? throw new ArgumentNullException(nameof(step));

            ActiveStepIndex = StepsIndex(step);

            if (ActiveStepIndex == Steps.Count - 1)
                IsLastStep = true;
            else
                IsLastStep = false;
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
