using System.ComponentModel.DataAnnotations;

namespace BlazorNifty.Pages.Components.Forms.Wizard
{
    public class FirstStepWizardModel
    {
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email je povinné pole")]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string RetypePassword { get; set; } = string.Empty;  
    }
}
