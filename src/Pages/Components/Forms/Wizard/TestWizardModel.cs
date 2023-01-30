using System.ComponentModel.DataAnnotations;

namespace BlazorNifty.Pages.Components.Forms.Wizard
{
    public class FirstStepWizardModel
    {
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string RetypePassword { get; set; } = string.Empty;

        //public string FirstName { get; set; } = string.Empty;

        //public string LastName { get; set; } = string.Empty;

        //public string? Company { get; set; }

        //public string? MemberType { get; set; }

        //public string Address { get; set; } = string.Empty;

        //public string? Address2 { get; set; }

        //public string City { get; set; } = string.Empty;

        //public string? ZipCode { get; set; }
    }
}
