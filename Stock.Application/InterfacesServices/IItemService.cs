using Stock.Stock.Application.Dto;

namespace Stock.Stock.Application.InterfacesServices
{
    public interface IItemService
    {
        Task<ItemDto> addAsync(ItemDto item);
        Task<GetItemDto> GetAsync(int id);
        Task<List<GetItemDto>> GetAllAsync();
        Task<int> deleteAsync(int id);
        Task<int> UpdateAsync(UpdateItemDto item);
        Task<int> IncreaseStockAsync(int itemId, int amount);
        Task<int> DecreaseStockAsync(int itemId, int amount);
    }
}
