using PHONE_SERVICE.Data.Enums;
using PHONE_SERVICE.Models.PhoneModelModels;
using System.ComponentModel.DataAnnotations;

namespace PHONE_SERVICE.Data.DTO
{
    public class PhoneModel
    {
        public PhoneModel()
        {
            
        }
        public PhoneModel(PhoneModelViewModel phoneModel)
        {
            PhoneModelId = phoneModel.PhoneModelId;
            Name = phoneModel.Name;
            PhoneBrand = phoneModel.PhoneBrand;
            Repairs = phoneModel.Repairs;
            RepairRequests = phoneModel.RepairRequests;
        }

        [Key]
        public int PhoneModelId { get; set; }
        public string Name { get; set; }
        public PhoneBrand PhoneBrand { get; set; }
        public virtual List<Repair> Repairs { get; set; }
        public virtual List<RepairRequest> RepairRequests { get; set; }
    }
}
