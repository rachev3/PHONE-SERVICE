namespace PHONE_SERVICE.Models.RepairModels
{
    public class RepairPageViewModel
    {
        public RepairPageViewModel(List<RepairViewModel> repairs)
        {
            Repairs = repairs;
        }

        public List<RepairViewModel> Repairs { get; set; }
    }
}
