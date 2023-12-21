using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Services
{
    public class PhoneModelRepairService : IPhoneModelRepairService
    {
        private readonly ApplicationDbContext dbContext;
        public PhoneModelRepairService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task<PhoneModelRepair> GetById(int phoneModelId, int repairId)
        {
            var data = await dbContext.PhoneModelsRepair.FirstOrDefaultAsync(r => r.RepairId == repairId && r.PhoneModelId == phoneModelId);
            return data;
        }
        public async Task Add(PhoneModelRepair phoneModelRepair)
        {
            await dbContext.PhoneModelsRepair.AddAsync(phoneModelRepair); 
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int phoneModelId, int repairId)
        {
            var data = await dbContext.PhoneModelsRepair.FirstOrDefaultAsync(r => r.RepairId == repairId && r.PhoneModelId == phoneModelId);
            dbContext.PhoneModelsRepair.Remove(data);
            await dbContext.SaveChangesAsync();
        }

    }
}
