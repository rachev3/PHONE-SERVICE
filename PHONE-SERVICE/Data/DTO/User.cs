using Microsoft.AspNetCore.Identity;

namespace PHONE_SERVICE.Data.DTO
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public List<Repair> Repairs { get; set; }
        public List<RepairRequest> RepairRequests { get; set; }
    }
}
