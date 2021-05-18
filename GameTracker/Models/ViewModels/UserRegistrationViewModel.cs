using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The Passwords Must Match")]
        [Required(ErrorMessage = "Verification Password Is Required")]
        public string VerificationPassword { get; set; }
    }
}
