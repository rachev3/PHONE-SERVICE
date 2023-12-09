using Microsoft.AspNetCore.Identity;
using PHONE_SERVICE.Models.UserModels;

namespace PHONE_SERVICE.Data.DTO
{
    public class User : IdentityUser
    {
        public User()
        {
            
        }
        public User(UserRegisterViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
            Address = model.Address;
            UserName = model.UserName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public RepairRequest ClientRepairRequest { get; set; }
        public List<RepairRequest> WorkerRepairRequests { get; set; }
    }
}
