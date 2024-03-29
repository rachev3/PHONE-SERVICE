﻿using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Data.Enums;

namespace PHONE_SERVICE.Models.RepairRequestModels
{
    public class RepairRequestViewModel
    {
        public RepairRequestViewModel()
        {
            
        }

        public RepairRequestViewModel(RepairRequest repairRequest)
        {
            RepairRequestId = repairRequest.RepairRequestId;
            RepairRequestType = repairRequest.RepairRequestType;
            Date = repairRequest.Date;
            RepairType = repairRequest.RepairType;
            PhoneModel = repairRequest.PhoneModel;
            Descripion = repairRequest.Description;
            Status = repairRequest.Status;
            Rating = repairRequest.Rating;
            Price = repairRequest.Price;
            PhoneModelId =  repairRequest.PhoneModelId;
            WorkerId = repairRequest.WorkerUserId;
        }

        public int RepairRequestId { get; set; }
        public RepairRequestType RepairRequestType { get; set; }
        public DateTime Date { get; set; }
        public RepairType RepairType { get; set; }
        public int PhoneModelId { get; set; }
        public PhoneModel PhoneModel { get; set; }
        public string? Descripion { get; set; }
        public RepairRequestStatus Status { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string WorkerId { get; set; }
    }
}
