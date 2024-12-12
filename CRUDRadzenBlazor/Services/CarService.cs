using CRUDRadzenBlazor.Models;
using CRUDRadzenBlazor.Repositories;

namespace CRUDRadzenBlazor.Services
{
    public class CarService(ICarRepository carRepository):ICarService
    {
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            try
            {
                return await carRepository.GetAllCarAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all cars: {ex.Message}", ex);
            }
        }
        public async Task<Car> GetByIdAsync(int id)
        {
            try
            {
                return await carRepository.GetCarByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving car with ID {id}: {ex.Message}", ex);
            }
        }
        public async Task UpdateCarAsync(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null.");
            }

            await carRepository.UpdateCarAsync(car);
        }

        public async Task AddCarAsync(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null.");
            }
            if (await carRepository.CarExistsAsync(car.Make, car.Model,car.Year))
            {
                throw new InvalidOperationException($"A car with Make '{car.Make}' and Model '{car.Model}' already exists.");
            }

            await carRepository.AddCarAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            try
            {
                await carRepository.DeleteCarAsync(id);
            }
            catch (Exception ex) {
                throw new Exception($"Error deleting car with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
