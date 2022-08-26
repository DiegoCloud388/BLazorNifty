using System.ComponentModel.DataAnnotations;

namespace BlazorNifty.Data.Commands
{
    public class CommandCreateUser
    {
        [Required]
        public string FirtName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int? StateId { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public bool? IsGdprConfirmed { get; set; }
    }
}
