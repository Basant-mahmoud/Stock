using Stock.Stock.Domain.Models;

namespace Stock.Stock.Domain.InterfacesRepo
{
    public interface IItemRepository
    {
          Task<Item> addAsync(Item item);
         Task<Item> GetAsync(int id);
         Task<List<Item>> GetAllAsync();
         Task<int> deleteAsync(Item item);
         Task<int> UpdateAsync(Item item);
        Task<Item> GetByNameAsync(string name);
    }
}
