using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Windows.Input;

namespace BlazorNifty.Components.MyWizards
{
    public partial class MyWizardStep
    {
        [CascadingParameter]
        public MyWizard Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public Func<bool>? OnValidSubmit { get; set; }

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
