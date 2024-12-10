using CRUDRadzenBlazor.Models;

namespace CRUDRadzenBlazor.Repositories
{
    public interface ICarRepository
    {
         Task AddCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<IEnumerable<Car>> GetAllCarAsync();
        Task<Car?> GetCarByIdAsync(int id);
        Task UpdateCarAsync(Car car);
        Task<bool> CarExistsAsync(string make, string model, int year);
    }
}
