using Microsoft.AspNetCore.Components.Server.Circuits;
using PHONE_SERVICE.Data.Enums;
using PHONE_SERVICE.Models.RepairModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

            Price = repair.Price;

        }
        public Repair(RepairViewModel repair)
        {
            RepairType = repair.RepairType;

            Price = repair.Price;
        }
        [Key]
        public int RepairId { get; set; }
        public RepairType RepairType { get; set; }
        public virtual List<PhoneModelRepair>? PhoneModelRepair { get; set; }

        public double Price { get; set; }

    }
}
