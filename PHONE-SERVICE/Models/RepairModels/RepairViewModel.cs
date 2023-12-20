using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;
using System.ComponentModel;

namespace PHONE_SERVICE.Models.RepairModels
{
    public class RepairViewModel
    {
        public RepairViewModel()
        {
            
        }
        public RepairViewModel(Repair repair)
        {
            RepairId = repair.RepairId;
            RepairType = repair.RepairType;
            Price = repair.Price;
        }
        public int RepairId { get; set; }
        public RepairType RepairType { get; set; }
        public PhoneModel PhoneModel { get; set; }
        public double Price { get; set; }
    }
}
