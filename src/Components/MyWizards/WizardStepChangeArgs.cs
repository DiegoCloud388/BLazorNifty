namespace BlazorNifty.Components.MyWizards
{
    public class WizardStepChangeArgs
    {
        public MyWizardStep CurrentStep { get; set; }

        public MyWizardStep TargetStep { get; set; }

        public WizardStepChangeArgs(MyWizardStep currentStep, MyWizardStep targetStep)
        {
            CurrentStep = currentStep;
            TargetStep = targetStep;
        }
    }
}
