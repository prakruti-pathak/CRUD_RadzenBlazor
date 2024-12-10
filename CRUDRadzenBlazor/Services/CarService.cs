using CRUDRadzenBlazor.Models;
using CRUDRadzenBlazor.Repositories;

namespace CRUDRadzenBlazor.Services
{
    public class CarService(ICarRepository carRepository):ICarService
    {
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await carRepository.GetAllCarAsync();
        }
        public async Task<Car> GetByIdAsync(int id)
        {
            return await carRepository.GetCarByIdAsync(id);
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
            await carRepository.DeleteCarAsync(id);
        }
    }
}
