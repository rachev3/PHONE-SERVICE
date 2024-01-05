using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Services
{
    public class RepairService : IRepairService
    {
        private readonly ApplicationDbContext dbContext;
        public RepairService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task Add(Repair repair)
        {
            await dbContext.Repairs.AddAsync(repair);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await dbContext.Repairs.FirstOrDefaultAsync(r => r.RepairId == id);
            dbContext.Repairs.Remove(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Repair>> GetAll()
        {
            var result = await dbContext.Repairs.Include(x=>x.PhoneModel).ToListAsync();
            return result;
        }

        public async Task<Repair> GetById(int id)
        {
            var result = await dbContext.Repairs.Include(x=>x.PhoneModel).FirstOrDefaultAsync(r => r.RepairId == id);
            return result;
        }

        public async Task<Repair> Update(int id, Repair repair)
        {
            dbContext.Update(repair);
            await dbContext.SaveChangesAsync();
            return repair;
        }
    }
}
