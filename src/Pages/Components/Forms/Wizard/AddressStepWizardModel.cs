namespace BlazorNifty.Pages.Components.Forms.Wizard
{
    public class AddressStepWizardModel
    {
        public string Address { get; set; } = string.Empty;

        public string? Address2 { get; set; }

        public string City { get; set; } = string.Empty;

        public string? ZipCode { get; set; }
    }
}
