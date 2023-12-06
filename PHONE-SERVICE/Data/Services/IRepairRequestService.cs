using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Services
{
    public interface IRepairRequestService
    {
        Task<List<RepairRequest>> GetAll();
        Task<RepairRequest> GetById(int id);
        Task Add(RepairRequest repairRequest);
        Task<RepairRequest> Update(int id, RepairRequest repairRequest);
        Task Delete(int id);
    }
}
