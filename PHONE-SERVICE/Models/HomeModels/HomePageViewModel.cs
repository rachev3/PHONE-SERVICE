using Microsoft.EntityFrameworkCore.ChangeTracking;
using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Models.HomeModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
                
        }
        public List<Repair> Decode { get; set; }
        public List<Repair> DisplayChange { get; set;}
        public List<Repair> ProtectorChange { get; set; }
        public List<Repair> BatteryChange { get; set;}
        public List<RepairRequest> Rated { get; set; }
    }
}
