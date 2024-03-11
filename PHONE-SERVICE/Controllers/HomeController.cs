using Microsoft.AspNetCore.Mvc;
using PHONE_SERVICE.Data.Services;
using PHONE_SERVICE.Models;
using PHONE_SERVICE.Models.HomeModels;
using System.Diagnostics;

namespace PHONE_SERVICE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepairService repairService;
        private readonly IRepairRequestService repairRequestService;

        public HomeController(ILogger<HomeController> logger, IRepairService repairService, IRepairRequestService repairRequestService)
        {
            _logger = logger;
            this.repairService = repairService;
            this.repairRequestService = repairRequestService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await repairService.GetAll();
            var requests = await repairRequestService.GetAll();
            requests =  requests.OrderByDescending(x=>x.Rating).ToList();

            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.BatteryChange = data.Where(x=>x.RepairType == Data.Enums.RepairType.BatteryChange).ToList();
            viewModel.ProtectorChange = data.Where(x => x.RepairType == Data.Enums.RepairType.ProtectorChange).ToList();
            viewModel.DisplayChange = data.Where(x => x.RepairType == Data.Enums.RepairType.DisplayChange).ToList();
            viewModel.Decode = data.Where(x => x.RepairType == Data.Enums.RepairType.Decode).ToList();
            viewModel.Rated = requests;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}