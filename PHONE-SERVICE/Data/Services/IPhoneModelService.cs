using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Models.HomeModels;

namespace PHONE_SERVICE.Data.Services
{
    public interface IPhoneModelService
    {
        Task<List<PhoneModel>> GetAll();
        Task<PhoneModel> GetById(int id);
        Task<PhoneModel> GetByBrandName(ClientMakeRequestViewModel model);
        Task Add(PhoneModel phoneModel);
        Task<PhoneModel> Update(int id, PhoneModel phoneModel);
        Task Delete(int id);
    }
}
