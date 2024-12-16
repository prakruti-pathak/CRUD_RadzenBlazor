using CRUDRadzenBlazor.Models;
using CRUDRadzenBlazor.Repositories;

namespace CRUDRadzenBlazor.Services
{
    public class CarService(ICarRepository carRepository):ICarService
    {
        public async Task<IEnumerable<Car>> GetAllAsync(string searchQuery = "")
        {
            try
            {
                // Use the searchQuery to filter by Make or Engine
                var carData = await carRepository.GetAllCarAsync(searchQuery);

                var cars = new List<Car>();

                foreach (var item in carData)
                {
                    var car = new Car
                    {
                        Id = item.Id,
                        Make = item.Make,
                        Model = item.Model,
                        YearId = item.YearId,
                        ColorId = item.ColorId,
                        Engine = item.Engine,
                        Price = item.Price,
                        Year = new Year
                        {
                            YearId = item.YearId,
                            YearName = item.Year.YearName
                        },
                        Color = new Color
                        {
                            ColorId = item.ColorId,
                            ColorName = item.Color.ColorName
                        }
                    };
                    cars.Add(car);
                }

                return cars;
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
            if (await carRepository.CarExistsAsync(car.Make, car.Model,car.YearId))
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

        public async Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            try
            {
                return await carRepository.GetAllColors();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all colors: {ex.Message}", ex);
            }
        }
        public async Task<IEnumerable<Year>> GetAllYearsAsync()
        {
            try
            {
                return await carRepository.GetAllYears();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all years: {ex.Message}", ex);
            }
        }
    }
}
