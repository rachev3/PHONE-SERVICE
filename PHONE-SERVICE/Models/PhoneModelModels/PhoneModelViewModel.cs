using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;

namespace PHONE_SERVICE.Models.PhoneModelModels
{
    public class PhoneModelViewModel
    {
        public PhoneModelViewModel()
        {
            
        }
        public PhoneModelViewModel(PhoneModel phoneModel)
        {
            PhoneModelId = phoneModel.PhoneModelId;
            Name = phoneModel.Name;
            PhoneBrand = phoneModel.PhoneBrand;

            RepairRequests = phoneModel.RepairRequests;
        }
        public int PhoneModelId { get; set; }
        public string Name { get; set; }
        public PhoneBrand PhoneBrand { get; set; }
        public List<Repair> Repairs { get; set; }
        public List<RepairRequest> RepairRequests { get; set; } 
    }
}
