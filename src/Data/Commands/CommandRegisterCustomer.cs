using System.ComponentModel.DataAnnotations;

namespace BlazorNifty.Data.Commands
{
    public class CommandRegisterCustomer
    {
        [Required(ErrorMessage = "The Full Name is required.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "The field E-mail is required.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The field Gendre is required.")]
        public int? GenderId { get; set; }

        [Required(ErrorMessage = "The field Country is required.")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "The field Birthdate is required.")]
        public DateTime? Birthdate { get; set; }

        [MaxLength(50)]
        public string? Comment { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree before submitting.")]
        public bool IsGdprConfirmed { get; set; }
    }
}
