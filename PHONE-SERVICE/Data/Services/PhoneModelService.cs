﻿using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Models.HomeModels;

namespace PHONE_SERVICE.Data.Services
{
    public class PhoneModelService : IPhoneModelService
    {
        private readonly ApplicationDbContext dbContext;
        public PhoneModelService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task Add(PhoneModel phoneModel)
        {
            await dbContext.PhoneModels.AddAsync(phoneModel);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await dbContext.PhoneModels.FirstOrDefaultAsync(pm => pm.PhoneModelId == id);
            dbContext.PhoneModels.Remove(result);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<PhoneModel>> GetAll()
        {
            var result = await dbContext.PhoneModels.ToListAsync();
            return result;
        }

        public async Task<PhoneModel> GetByBrandName(ClientMakeRequestViewModel model)
        {
            var result = await dbContext.PhoneModels.Include(x=>x.Repairs).FirstOrDefaultAsync(x => x.PhoneBrand == model.Phone.PhoneBrand && x.Name == model.Phone.Name);
            return result;
        }
        public async Task<PhoneModel> GetById(int id)
        {
            var result = await dbContext.PhoneModels.FirstOrDefaultAsync(pm=>pm.PhoneModelId==id);
            return result;
        }

        public async Task<PhoneModel> Update(int id, PhoneModel phoneModel)
        {
            dbContext.Update(phoneModel);
            await dbContext.SaveChangesAsync();
            return phoneModel;
        }
    }
}
