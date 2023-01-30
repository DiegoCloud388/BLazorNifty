using System.ComponentModel.DataAnnotations;

namespace BlazorNifty.Pages.Components.Forms.Wizard
{
    public class SecondStepWizardModel
    {
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string? Company { get; set; }

        public string? MemberType { get; set; }
    }
}
