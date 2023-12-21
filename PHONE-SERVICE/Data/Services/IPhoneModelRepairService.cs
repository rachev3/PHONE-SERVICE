using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Services
{
    public interface IPhoneModelRepairService
    {
        Task<PhoneModelRepair> GetById(int phoneModelId, int repairId);
        Task Add(PhoneModelRepair phoneModelRepair);
        Task Delete(int phoneModelId, int repairId);
    }
}
