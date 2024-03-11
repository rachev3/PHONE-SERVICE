using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Services;
using PHONE_SERVICE.Models.PhoneModelModels;
using PHONE_SERVICE.Models.RepairModels;

namespace PHONE_SERVICE.Controllers
{
    public class RepairController : Controller
    {
        private readonly IRepairService repairService;
        private readonly IPhoneModelService phoneModelService;

        public RepairController(IRepairService repairService, IPhoneModelService phoneModelService)
        {
            this.repairService = repairService;
            this.phoneModelService = phoneModelService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await repairService.GetAll();
            var repairs = data.Select(x => new RepairViewModel(x)).ToList();
            var viewModel = new RepairPageViewModel(repairs);

            return View("Index", viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var phoneModels = await phoneModelService.GetAll();
            var viewModel = new RepairCreateViewModel(phoneModels);
            
            return View("Create", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RepairCreateViewModel repair)
        {
            var dboRepair = new Repair(repair);

            await repairService.Add(dboRepair);

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var repair = await repairService.GetById(id);
            var phoneModels = phoneModelService.GetAll().Result;
            RepairCreateViewModel repairViewModel = new(repair,phoneModels);

            if (repair == null)
            {
                return View("404");
            }

            return View("Edit", repairViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(RepairCreateViewModel repair)
        {
            var dto = await repairService.GetById(repair.RepairId);

            dto.RepairType = repair.RepairType;
            dto.PhoneModel = repair.PhoneModel;
            dto.Price = repair.Price;

            try
            {
                await repairService.Update(repair.RepairId,dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the changes: " + ex.Message);
                return View(repair);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var repair = await repairService.GetById(id);
            RepairViewModel repairViewModel = new(repair);

            if (repair == null)
            {
                return View("404");
            }

            return View("Delete", repairViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var repair = await repairService.GetById(id);

            if (repair == null)
            {
                return View("404");
            }

            await repairService.Delete(id);

          return RedirectToAction("Index");
        }

    }
}
