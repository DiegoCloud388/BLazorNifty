using Microsoft.AspNetCore.Components;

namespace BlazorNifty.Components.Wizards
{
    public partial class WizardStep<TModel>
    {
        /// <summary>
        /// The <see cref="Wizard"/> container
        /// </summary>
        [CascadingParameter]
        protected internal Wizard<TModel> Parent { get; set; }

        /// <summary>
        /// The Child Content of the current <see cref="WizardStep"/>
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

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

    }
}
