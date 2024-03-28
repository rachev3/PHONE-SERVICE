using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;

namespace PHONE_SERVICE.Models.HomeModels
{
    public class ClientMakeRequestViewModel
    {
        public ClientMakeRequestViewModel()
        {

        }
        public RepairType RepairType { get; set; }
        public RepairRequestType RepairRequestType { get; set; }
        public double Price { get; set; } = 0;
        public List<Repair> Repairs { get; set; }

        public PhoneModel Phone { get; set; }
        public List<PhoneModel> Phones { get; set; }
    }
}
