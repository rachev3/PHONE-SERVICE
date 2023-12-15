using Microsoft.AspNetCore.Identity;
using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Models.UserModels
{
    public class UserViewModel
    {
       

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } 
    }
}
