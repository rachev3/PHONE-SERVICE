using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Services
{
    public interface IPhoneModelService
    {
        Task<List<PhoneModel>> GetAll();
        Task<PhoneModel> GetById(int id);
        Task Add(PhoneModel phoneModel);
        Task<PhoneModel> Update(int id, PhoneModel phoneModel);
        Task Delete(int id);
    }
}
