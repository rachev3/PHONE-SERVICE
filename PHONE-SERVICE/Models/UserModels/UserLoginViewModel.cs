using System.ComponentModel;

namespace PHONE_SERVICE.Models.UserModels
{
    public class UserLoginViewModel
    {
        [DisplayName("Username")]
        public string? UserName { get; set; }
        public string? Email { get; set; }
        //[DataType(DataType.Password)]

        public string? Password { get; set; }

    }
}
