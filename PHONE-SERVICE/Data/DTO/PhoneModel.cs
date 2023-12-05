using PHONE_SERVICE.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PHONE_SERVICE.Data.DTO
{
    public class PhoneModel
    {
        [Key]
        public int PhoneModelId { get; set; }
        public string Name { get; set; }
        public PhoneBrand PhoneBrand { get; set; }
        public virtual List<Repair> Repairs { get; set; }
        public virtual List<RepairRequest> RepairRequests { get; set; }
    }
}
