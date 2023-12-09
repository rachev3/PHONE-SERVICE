using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PHONE_SERVICE.Models.UserModels
{
    public class UserRegisterViewModel
    {
        [DisplayName("Username:")]
        public string UserName { get; set; }

        [DisplayName("First name:")]
        public string FirstName { get; set; }

        [DisplayName("Last name:")]
        public string LastName { get; set; }
        [DisplayName("Address:")]
        public string Address { get; set; }

        [DisplayName("Email:")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        [DisplayName("Password:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        [DisplayName("Confirm password:")]
        public string ConfirmPassword { get; set; }

    }
}
