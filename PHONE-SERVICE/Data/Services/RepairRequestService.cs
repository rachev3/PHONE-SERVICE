using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;
using System.Runtime.InteropServices;

namespace PHONE_SERVICE.Data.Services
{
    public class RepairRequestService : IRepairRequestService
    {
        private readonly ApplicationDbContext dbContext;

        public RepairRequestService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task Add(RepairRequest repairRequest)
        {
            await dbContext.RepairRequests.AddAsync(repairRequest);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await dbContext.RepairRequests.FirstOrDefaultAsync(rp => rp.RepairRequestId == id);
            dbContext.RepairRequests.Remove(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<RepairRequest>> GetAll()
        {
            var result = await dbContext.RepairRequests.ToListAsync();
            return result;
        }

        public async Task<RepairRequest> GetById(int id)
        {
            var result = await dbContext.RepairRequests.FirstOrDefaultAsync(rp=>rp.RepairRequestId == id);
            return result;
        }

        public async Task<RepairRequest> Update(int id, RepairRequest repairRequest)
        {
            dbContext.Update(repairRequest);
            await dbContext.SaveChangesAsync();
            return repairRequest;
        }
    }
}
