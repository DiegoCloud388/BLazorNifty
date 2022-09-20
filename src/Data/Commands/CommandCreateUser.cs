using System.ComponentModel.DataAnnotations;

namespace BlazorNifty.Data.Commands
{
    public class CommandCreateUser
    {
        [Required(ErrorMessage = "The First name is required.")]
        public string FirtName { get; set; }

        [Required(ErrorMessage = "The field Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field User name is required.")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field State is required.")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "The field Zip is required.")]
        public string Zip { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree before submitting.")]
        public bool IsGdprConfirmed { get; set; }
    }
}
