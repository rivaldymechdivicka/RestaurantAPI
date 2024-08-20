using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class FoodService : IFoodService
    {
        private readonly RestaurantDBContext _context;

        public FoodService(RestaurantDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> GetFoodByIdAsync(int id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task<Food> CreateFoodAsync(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task UpdateFoodAsync(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodAsync(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }
        }
    }
}