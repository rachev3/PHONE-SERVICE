using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;

namespace PHONE_SERVICE.Models.RepairRequestModels
{
    public class RepairRequestCreateViewModel
    {
        public RepairRequestCreateViewModel()
        {

        }
        public RepairRequestCreateViewModel(List<PhoneModel> phoneModels)
        {

            PhoneModels = phoneModels;

        }

        public RepairRequestCreateViewModel(RepairRequest repairRequest, List<PhoneModel> phoneModels)
        {
            RepairRequestId = repairRequest.RepairRequestId;
            RepairRequestType = repairRequest.RepairRequestType;
            DateOnly = repairRequest.DateOnly;
            RepairType = repairRequest.RepairType;
            PhoneModel = repairRequest.PhoneModel;
            Descripion = repairRequest.Description;
            Status = repairRequest.Status;
            Rating = repairRequest.Rating;
            Price = repairRequest.Price;
            PhoneModels = phoneModels;
            PhoneModelId = repairRequest.PhoneModelId;
            WorkerId = repairRequest.WorkerUserId;
            ClientId = repairRequest.ClientUserId;
        }

        public int RepairRequestId { get; set; }
        public RepairRequestType RepairRequestType { get; set; }
        public DateOnly DateOnly { get; set; }
        public RepairType RepairType { get; set; }
        public int PhoneModelId { get; set; }
        public PhoneModel PhoneModel { get; set; }
        public List<PhoneModel> PhoneModels { get; set; }
        public string? Descripion { get; set; }
        public RepairRequestStatus Status { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string? WorkerId { get; set; }
        public string? ClientId { get; set; }
        public string ClientEmail { get; set; }
    }
}
