namespace PHONE_SERVICE.Models.RepairRequestModels
{
    public class RepairRequestPageViewModel
    {
        public RepairRequestPageViewModel(List<RepairRequestViewModel> repairRequests)
        {
            RepairRequests = repairRequests;
        }
        public List<RepairRequestViewModel> RepairRequests { get; set; }
    }
}
