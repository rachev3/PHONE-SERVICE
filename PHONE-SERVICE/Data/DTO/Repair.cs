using PHONE_SERVICE.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PHONE_SERVICE.Data.DTO
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }
        public RepairType RepairType { get; set; }

        public virtual PhoneModel PhoneModel { get; set; }

        public double Price { get; set; }

    }
}
