using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Services
{
    public interface IRepairService
    {
        Task<List<Repair>> GetAll();
        Task<Repair> GetById(int id);
        Task Add(Repair repair);
        Task<Repair> Update(int id, Repair repair);
        Task Delete(int id);
    }
}
