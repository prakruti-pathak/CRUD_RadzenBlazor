using CRUDRadzenBlazor.Models;

namespace CRUDRadzenBlazor.Services
{
    public interface ICarService
    {
        Task AddCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync(string searchQuery = "");
        Task<IEnumerable<Color>> GetAllColorsAsync();
        Task<IEnumerable<Year>> GetAllYearsAsync();
        Task<Car> GetByIdAsync(int id);
        Task UpdateCarAsync(Car car);
    }
}
