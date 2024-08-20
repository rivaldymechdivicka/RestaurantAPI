using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<Food>> GetAllFoodsAsync();
        Task<Food> GetFoodByIdAsync(int id);
        Task<Food> CreateFoodAsync(Food food);
        Task UpdateFoodAsync(Food food);
        Task DeleteFoodAsync(int id);
    }
}