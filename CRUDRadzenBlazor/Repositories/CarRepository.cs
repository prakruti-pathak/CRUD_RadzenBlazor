using CRUDRadzenBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDRadzenBlazor.Repositories
{
    public class CarRepository(AppDbContext appDbContext):ICarRepository
    {
        public async Task<IEnumerable<Car>> GetAllCarAsync()
        {
            try
            {
                return await appDbContext.Cars.Include(c => c.Color).Include(c => c.Year).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cars: {ex.Message}");
                throw;
            }
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            try
            {
                return await appDbContext.Cars.Include(c => c.Year)  
        .Include(c => c.Color)
        .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching car by ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task AddCarAsync(Car car)
        {
            try
            {
                if (car != null)
                {
                    await appDbContext.Cars.AddAsync(car);
                    await appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding car: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCarAsync(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null.");
            }

            try
            {
                var trackedCar = appDbContext.Cars.Local.FirstOrDefault(c => c.Id == car.Id);
                if (trackedCar != null)
                {
                    appDbContext.Entry(trackedCar).CurrentValues.SetValues(car);
                }
                else
                {

                    appDbContext.Cars.Attach(car);
                    appDbContext.Entry(car).State = EntityState.Modified;
                }

                await appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating car: {ex.Message}");
                throw;
            }
        }


        public async Task DeleteCarAsync(int id)
        {
            try
            {
                var car = await appDbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
                if (car != null)
                {
                    appDbContext.Cars.Remove(car);
                    await appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting car with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> CarExistsAsync(string make, string model, int year)
        {
            try
            {
                return await appDbContext.Cars.AnyAsync(c =>
                    c.Make.ToLower() == make.ToLower() &&
                    c.Model.ToLower() == model.ToLower() &&
                    c.YearId == year
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if car exists: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Color>>  GetAllColors()
        {
            return await appDbContext.Colors.ToListAsync();
        }
        public async Task<IEnumerable<Year>> GetAllYears()
        {
            return await appDbContext.Years.ToListAsync();
        }

    }
}
