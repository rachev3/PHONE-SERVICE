using PHONE_SERVICE.Data.Enums;

namespace PHONE_SERVICE.Models.RepairRequestModels
{
    public class RepairRequestPageViewModel
    {
        public RepairRequestPageViewModel(List<RepairRequestViewModel> repairRequests)
        {
            RepairRequests = repairRequests;
        }
        public List<RepairRequestViewModel> RepairRequests { get; set; }
        public RepairRequestStatus Status { get; set; }
        public RepairRequestType RequestType { get; set; }
    }
}
