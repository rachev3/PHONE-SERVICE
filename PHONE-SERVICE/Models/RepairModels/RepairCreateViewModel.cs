using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;

namespace PHONE_SERVICE.Models.RepairModels
{
    public class RepairCreateViewModel
    {
        public RepairCreateViewModel()
        {
            
        }
        public RepairCreateViewModel(List<PhoneModel> phoneModels)
        {
            PhoneModels = phoneModels;
        }
        public RepairCreateViewModel(Repair repair, List<PhoneModel> phoneModels)
        {
            RepairId = repair.RepairId;
            RepairType = repair.RepairType;
            PhoneModel = repair.PhoneModel;
            Price = repair.Price;
            PhoneModels = phoneModels;
        }
        public RepairCreateViewModel(Repair repair)
        {
            RepairId = repair.RepairId;
            RepairType = repair.RepairType;
            PhoneModel = repair.PhoneModel;
            Price = repair.Price;
        }
        public int RepairId { get; set; }
        public RepairType RepairType { get; set; }
        public int PhoneModelId { get; set; }
        public PhoneModel PhoneModel { get; set; }
        public List<PhoneModel> PhoneModels { get; set; }
        public double Price { get; set; }
    }
}
