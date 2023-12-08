using Microsoft.AspNetCore.Mvc;
using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Services;
using PHONE_SERVICE.Models.RepairModels;
using PHONE_SERVICE.Models.RepairRequestModels;

namespace PHONE_SERVICE.Controllers
{
    public class RepairRequestController : Controller
    {
        //
        private readonly IRepairRequestService repairRequestService;
        private readonly IPhoneModelService phoneModelService;

        public RepairRequestController(IRepairRequestService repairRequestService, IPhoneModelService phoneModelService)
        {
            this.repairRequestService = repairRequestService;
            this.phoneModelService = phoneModelService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await repairRequestService.GetAll();
            var repairRequests = data.Select(x => new RepairRequestViewModel(x)).ToList();
            var viewModel = new RepairRequestPageViewModel(repairRequests);

            return View("Index", viewModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            //if there are 0 phoneModels???
            var phoneModels = phoneModelService.GetAll().Result;
            var viewModel = new RepairRequestCreateViewModel(phoneModels);

            return View("Create", viewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RepairRequestCreateViewModel repairRequest)
        {
            var dbo = new RepairRequest(repairRequest);

            await repairRequestService.Add(dbo);

            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var repairRequest = await repairRequestService.GetById(id);
            var phoneModels = phoneModelService.GetAll().Result;
            RepairRequestCreateViewModel repairViewModel = new(repairRequest, phoneModels);

            if (repairRequest == null)
            {
                return View("404");
            }

            return View("Edit", repairViewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(RepairRequestCreateViewModel repairRequest)
        {
            var dto = await repairRequestService.GetById(repairRequest.RepairRequestId);

            dto.RepairRequestType = repairRequest.RepairRequestType;
            dto.DateOnly = repairRequest.DateOnly;
            dto.RepairType = repairRequest.RepairType;
            dto.PhoneModel = repairRequest.PhoneModel;
            dto.Description = repairRequest.Descripion;
            dto.Status = repairRequest.Status;
            dto.Rating = repairRequest.Rating;
            dto.Price = repairRequest.Price;
            dto.PhoneModelId = repairRequest.PhoneModelId;

            await repairRequestService.Update(repairRequest.RepairRequestId, dto);

            return RedirectToAction("Index");
        }

       

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var repair = await repairRequestService.GetById(id);

            if (repair == null)
            {
                return View("404");
            }

            await repairRequestService.Delete(id);

            return RedirectToAction("Index");
        }

    }
}
