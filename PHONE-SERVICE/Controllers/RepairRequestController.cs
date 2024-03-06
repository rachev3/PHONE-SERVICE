using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;
using PHONE_SERVICE.Data.Services;
using PHONE_SERVICE.Models.RepairModels;
using PHONE_SERVICE.Models.RepairRequestModels;
using System.Security.Claims;

namespace PHONE_SERVICE.Controllers
{
    public class RepairRequestController : Controller
    {
        private readonly IRepairRequestService repairRequestService;
        private readonly IPhoneModelService phoneModelService;
        private readonly UserManager<User> userManager;

        public RepairRequestController(IRepairRequestService repairRequestService, IPhoneModelService phoneModelService, UserManager<User> userManager)
        {
            this.repairRequestService = repairRequestService;
            this.phoneModelService = phoneModelService;
            this.userManager = userManager;
        }
        [Authorize(Roles = "Admin, Worker")]
        public async Task<IActionResult> Index()
        {
            var data = await repairRequestService.GetAll();
            var repairRequests = data.Select(x => new RepairRequestViewModel(x)).ToList();
            var viewModel = new RepairRequestPageViewModel(repairRequests);

            return View("Index", viewModel);
        }

        [Authorize(Roles = "Admin, Worker")]
        public async Task<IActionResult> Search(RepairRequestType? requestType, RepairRequestStatus? status)
        {
            var data = await repairRequestService.GetAll();

            if (requestType != null) data = data.Where(d => d.RepairRequestType == requestType).ToList();
            if (status != null) data = data.Where(d => d.Status == status).ToList();

            var repairRequests = data.Select(x => new RepairRequestViewModel(x)).ToList();
            var viewModel = new RepairRequestPageViewModel(repairRequests);

            viewModel.Status = status;
            viewModel.RequestType = requestType;



            return View("Index", viewModel);
        }

        [Authorize(Roles = "Admin, Worker")]
        public async Task<IActionResult> SortByDate(string sortOrder, RepairRequestType? type, RepairRequestStatus? status)
        {
            var data = await repairRequestService.GetAll();

            if (type != null) data = data.Where(d => d.RepairRequestType == type).ToList();
            if (status != null) data = data.Where(d => d.Status == status).ToList();

            ViewData["DateSortParam"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            switch (sortOrder)
            {
                case "date_desc":
                    data = data.OrderBy(i => i.Date).ToList();
                    break;
                default:
                    data = data.OrderByDescending(i => i.Date).ToList();
                    break;
            }

            var repairRequests = data.Select(x => new RepairRequestViewModel(x)).ToList();
            var viewModel = new RepairRequestPageViewModel(repairRequests);

            viewModel.Status = status;
            viewModel.RequestType = type;

            return View("Index", viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ClientRepairRequests()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var data = await repairRequestService.GetAll();
            var filtered = data.Where(x => x.ClientUserId == userId);
            var repairRequests = filtered.Select(x => new RepairRequestViewModel(x)).ToList();
            var viewModel = new RepairRequestPageViewModel(repairRequests);
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Rate(int repairRequestId, int rating)
        {
            var dto = await repairRequestService.GetById(repairRequestId);

            dto.Rating = rating;

            await repairRequestService.Update(repairRequestId, dto);
            return Json(new { success = true });
        }

        [HttpGet]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> WorkerRepairRequests()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var data = await repairRequestService.GetAll();
            var filtered = data.Where(x => x.WorkerUserId == userId);
            var repairRequests = filtered.Select(x => new RepairRequestViewModel(x)).ToList();
            var viewModel = new RepairRequestPageViewModel(repairRequests);
            return View(viewModel);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Worker")]
        public async Task<IActionResult> Create()
        {
            //if there are 0 phoneModels???
            var phoneModels = phoneModelService.GetAll().Result;
            var viewModel = new RepairRequestCreateViewModel(phoneModels);

            return View("Create", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Worker")]
        public async Task<IActionResult> Create(RepairRequestCreateViewModel repairRequest)
        {

            var user = await userManager.Users
                       .Include(u => u.ClientRepairRequests)
                       .FirstOrDefaultAsync(u => u.Email == repairRequest.ClientEmail);

            bool hasUncompletedRequests = false;
            if (user == null)
            {

                return BadRequest("User not found");
            }
            hasUncompletedRequests = user.ClientRepairRequests.Any(req => req.Status != RepairRequestStatus.Completed);

            if (hasUncompletedRequests == true)
            {
                throw new ArgumentException("CANT");
            }

            repairRequest.Status = RepairRequestStatus.PendingConfirmation;

            if (repairRequest.RepairRequestType == RepairRequestType.Fast)
            {
                repairRequest.Price *= 1.5;
            }
            else if (repairRequest.RepairRequestType == RepairRequestType.Express)
            {
                repairRequest.Price *= 2;
            }

            repairRequest.Date = DateTime.Now;

            var dbo = new RepairRequest(repairRequest);
            dbo.WorkerUserId = repairRequest.WorkerId;
            if (user != null)
            {
                dbo.ClientUserId = user.Id;
            }

            await repairRequestService.Add(dbo);

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Worker")]
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
        [Authorize(Roles = "Admin, Worker")]
        public async Task<IActionResult> Edit(RepairRequestCreateViewModel repairRequest)
        {
            var dto = await repairRequestService.GetById(repairRequest.RepairRequestId);

            dto.RepairRequestType = repairRequest.RepairRequestType;
            //dto.DateOnly = repairRequest.DateOnly;
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
        [Authorize(Roles = "Admin, Worker")]
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
