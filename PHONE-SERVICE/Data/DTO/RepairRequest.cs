using Microsoft.EntityFrameworkCore.ChangeTracking;
using PHONE_SERVICE.Data.Enums;
using PHONE_SERVICE.Models.RepairRequestModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHONE_SERVICE.Data.DTO
{
    public class RepairRequest
    {
        public RepairRequest()
        {

        }
        public RepairRequest(RepairRequestCreateViewModel repairRequest)
        {
            RepairRequestType = repairRequest.RepairRequestType;
            DateOnly = repairRequest.DateOnly;
            RepairType = repairRequest.RepairType;
            PhoneModel = repairRequest.PhoneModel;
            Description = repairRequest.Descripion;
            Status = repairRequest.Status;
            Rating = repairRequest.Rating;
            Price = repairRequest.Price;
            PhoneModelId = repairRequest.PhoneModelId;
        }
        [Key]
        public int RepairRequestId { get; set; }
        public RepairRequestType RepairRequestType { get; set; }

        //User

        public DateTime Date
        {
            get => new DateTime(DateOnly.Year, DateOnly.Month, DateOnly.Day);
            set => DateOnly = new DateOnly(value.Year, value.Month, value.Day);
        }

        [NotMapped]
        public DateOnly DateOnly { get; set; }
        public RepairType RepairType { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        public int PhoneModelId { get; set; }
        public virtual PhoneModel? PhoneModel { get; set; }
        public string? Description { get; set; }
        public RepairRequestStatus Status { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
    }
}
