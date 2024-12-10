using CRUDRadzenBlazor.Models;

namespace CRUDRadzenBlazor.Services
{
    public interface ICarService
    {
        Task AddCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task UpdateCarAsync(Car car);
    }
}
