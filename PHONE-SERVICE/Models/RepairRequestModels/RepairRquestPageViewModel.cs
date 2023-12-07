namespace PHONE_SERVICE.Models.RepairRequestModels
{
    public class RepairRquestPageViewModel
    {
        public RepairRquestPageViewModel(List<RepairRequestViewModel> repairRequests)
        {
            RepairRequests = repairRequests;
        }
        public List<RepairRequestViewModel> RepairRequests { get; set; }
    }
}
