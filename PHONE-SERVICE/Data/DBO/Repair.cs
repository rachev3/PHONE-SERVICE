using Microsoft.AspNetCore.Components.Server.Circuits;
using PHONE_SERVICE.Data.Enums;
using PHONE_SERVICE.Models.RepairModels;
using System.ComponentModel.DataAnnotations;

namespace PHONE_SERVICE.Data.DTO
{
    public class Repair
    {
        public Repair()
        {

        }
        public Repair(RepairCreateViewModel repair)
        {
            RepairType = repair.RepairType;
            PhoneModel = repair.PhoneModel;
            Price = repair.Price;
            PhoneModelId = repair.PhoneModelId;
        }
        public Repair(RepairViewModel repair)
        {
            RepairType = repair.RepairType;
            PhoneModel = repair.PhoneModel;
            Price = repair.Price;
        }
        [Key]
        public int RepairId { get; set; }
        public RepairType RepairType { get; set; }
        public int PhoneModelId { get; set; }
        public virtual PhoneModel? PhoneModel { get; set; }

        public double Price { get; set; }

    }
}
