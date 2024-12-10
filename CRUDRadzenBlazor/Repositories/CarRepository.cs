using CRUDRadzenBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDRadzenBlazor.Repositories
{
    public class CarRepository(AppDbContext appDbContext):ICarRepository
    {
        public async Task<IEnumerable<Car>> GetAllCarAsync()
        {
            return await appDbContext.Cars.ToListAsync();
        }
        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await appDbContext.Cars.FirstOrDefaultAsync(c => c.Id ==id);
        }
        public async Task AddCarAsync(Car car)
        {
            if (car != null)
            {
                await appDbContext.Cars.AddAsync(car);
                await appDbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateCarAsync(Car car)
        {
            if (car != null)
            {
                appDbContext.Cars.Update(car);
                await appDbContext.SaveChangesAsync();            
            }
        }
        public async Task DeleteCarAsync(int id)
        {
            var car = await appDbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                appDbContext.Cars.Remove(car);
                await appDbContext.SaveChangesAsync();
            }
        }
        public async Task<bool> CarExistsAsync(string make, string model,int year)
        {
            return await appDbContext.Cars.AnyAsync(c => c.Make.ToLower() == make.ToLower() && c.Model.ToLower() == model.ToLower() && c.Year==year);
        }
       
    }
}
