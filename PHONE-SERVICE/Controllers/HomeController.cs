using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PHONE_SERVICE.Data.Enums;
using PHONE_SERVICE.Data.Services;
using PHONE_SERVICE.Models;
using PHONE_SERVICE.Models.HomeModels;
using System.Diagnostics;

namespace PHONE_SERVICE.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepairService repairService;
        private readonly IRepairRequestService repairRequestService;
        private readonly IPhoneModelService phoneModelService;

        public HomeController(IRepairService repairService, IRepairRequestService repairRequestService, IPhoneModelService phoneModelService)
        {
            this.repairService = repairService;
            this.repairRequestService = repairRequestService;
            this.phoneModelService = phoneModelService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await repairService.GetAll();
            var requests = await repairRequestService.GetAll();
            requests =  requests.OrderByDescending(x=>x.Rating).ToList();

            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.BatteryChange = data.Where(x=>x.RepairType == RepairType.BatteryChange).ToList();
            viewModel.ProtectorChange = data.Where(x => x.RepairType == RepairType.ProtectorChange).ToList();
            viewModel.DisplayChange = data.Where(x => x.RepairType == RepairType.DisplayChange).ToList();
            viewModel.Decode = data.Where(x => x.RepairType == RepairType.Decode).ToList();
            viewModel.Rated = requests;

            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Worker, Client")]
        public async Task<IActionResult> ClientMakeRequest()
        {
            ClientMakeRequestViewModel viewModel = new ClientMakeRequestViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetPhoneModels(string phonebrand)
        {
            var phoneModels = await phoneModelService.GetAll();
            phoneModels = phoneModels.Where(x => x.PhoneBrand.ToString() == phonebrand).ToList();
            var names = phoneModels.Select(phoneModels => phoneModels.Name).ToList();   

            return Json(names);
        }

        [HttpPost]
        public async Task<IActionResult> GetRepairTypes(ClientMakeRequestViewModel model)
        {
            var phoneModel = await phoneModelService.GetByBrandName(model);
            var repairTypes = await repairService.GetAll();
            var repairs = repairTypes.Where(x => x.PhoneModelId == phoneModel.PhoneModelId)
                                     .Select(group => new
                                     {
                                         group.RepairType,
                                         group.Price
                                     })
                                     .ToList();

            return Json(repairs);
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