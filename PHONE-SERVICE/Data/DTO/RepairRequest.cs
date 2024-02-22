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
            Date = repairRequest.Date;
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

        public DateTime Date { get; set; }
    
        public RepairType RepairType { get; set; }
        public string? ClientUserId { get; set; }
        [ForeignKey(nameof(ClientUserId))]
        public virtual User? ClientUser { get; set; }
        public string? WorkerUserId { get; set; }
        [ForeignKey(nameof(WorkerUserId))]
        public User? WorkerUser { get; set; }
        public int PhoneModelId { get; set; }
        public virtual PhoneModel? PhoneModel { get; set; }
        public string? Description { get; set; }
        public RepairRequestStatus Status { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
    }
}
