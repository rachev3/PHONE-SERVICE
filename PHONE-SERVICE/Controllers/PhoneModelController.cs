using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Services;
using PHONE_SERVICE.Models.PhoneModelModels;

namespace PHONE_SERVICE.Controllers
{
    public class PhoneModelController:Controller
    {
        private readonly IPhoneModelService phoneModelService;

        public PhoneModelController(IPhoneModelService phoneModelService)
        {
            this.phoneModelService = phoneModelService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await phoneModelService.GetAll();
            var phoneModels = data.Select(x => new PhoneModelViewModel(x)).ToList();
            var viewModel = new PhoneModelPageViewModel(phoneModels);

            return View("Index", viewModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(PhoneModelViewModel phoneModel)
        {
            var dbo = new PhoneModel(phoneModel);
           
            await phoneModelService.Add(dbo);

            var data = await phoneModelService.GetAll();
            var phoneModels = data.Select(x => new PhoneModelViewModel(x)).ToList();
            var viewModel = new PhoneModelPageViewModel(phoneModels);

            return View("Index", viewModel);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var phoneModel = await phoneModelService.GetById(id);
            PhoneModelViewModel phoneModelViewModel = new(phoneModel);

            if (phoneModel == null)
            {
                return View("404");
            }

            return View("Edit", phoneModelViewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(PhoneModelViewModel phoneModel)
        {
            var dto = await phoneModelService.GetById(phoneModel.PhoneModelId);

            dto.Name = phoneModel.Name;
            dto.PhoneBrand = phoneModel.PhoneBrand;
            dto.Repairs = phoneModel.Repairs;
            dto.RepairRequests = phoneModel.RepairRequests;

            await phoneModelService.Update(phoneModel.PhoneModelId, dto);

            return View("Index", Returner());
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var phoneModel = await phoneModelService.GetById(id);
            PhoneModelViewModel phoneModelView = new(phoneModel);

            if (phoneModel == null)
            {
                return View("404");
            }

            return View("Delete", phoneModelView);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirm(int phoneModelId)
        {
            var phoneModel = await phoneModelService.GetById(phoneModelId);

            if (phoneModel == null)
            {
                return View("404");
            }

            await phoneModelService.Delete(phoneModelId);

            return View("Index", Returner());
        }

        public async Task<PhoneModelPageViewModel> Returner()
        {
            var data = await phoneModelService.GetAll();
            var phoneModels = data.Select(x => new PhoneModelViewModel(x)).ToList();
            var viewModel = new PhoneModelPageViewModel(phoneModels);

            return viewModel;
        }
    }
}
