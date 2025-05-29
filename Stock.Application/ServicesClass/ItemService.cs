using AutoMapper;
using Stock.Migrations;
using Stock.Stock.Application.Dto;
using Stock.Stock.Application.InterfacesServices;
using Stock.Stock.Domain.InterfacesRepo;
using Stock.Stock.Domain.Models;

namespace Stock.Stock.Application.ServicesClass
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        public async Task<ItemDto> addAsync(ItemDto item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                    throw new Exception("Item name cannot be empty.");

                if (item.StockQuantity < 0)
                    throw new Exception("Stock quantity cannot be negative.");

                var existingItem = await _itemRepo.GetByNameAsync(item.Name.ToLower());
                if (existingItem != null)
                    throw new Exception("An item with the same name already exists.");

                var itemEntity = _mapper.Map<Item>(item);

                var addedEntity = await _itemRepo.addAsync(itemEntity);
                var itemdto = _mapper.Map<ItemDto>(addedEntity);

                return itemdto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the item: " + ex.Message);
            }
        }
        public async Task<int> deleteAsync(int id)
        {
            try
            {
                var exist = await _itemRepo.GetAsync(id);
                if(exist==null)
                    throw new Exception("Cant find this item ");
                var result = await _itemRepo.deleteAsync(exist);
                if(result==0)
                    throw new Exception("Cant delete this item ");
                 return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Deleteing the item: " + ex.Message);
            }
        }

        public async Task<List<GetItemDto>> GetAllAsync()
        {
            try
            {
                var list = await _itemRepo.GetAllAsync();
                if(list==null)
                      return new List<GetItemDto>();
                var itemsdto = _mapper.Map<List<GetItemDto>>(list);
                return itemsdto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Get All Item the item: " + ex.Message);
            }

        }

        public async Task<GetItemDto> GetAsync(int id)
        {
            try
            {
                var exsit = await _itemRepo.GetAsync(id);
                if(exsit==null)
                    throw new Exception("Cant find this item plz add it");
                var itemdto = _mapper.Map<GetItemDto>(exsit);
                return itemdto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Get the item: " + ex.Message);
            }


        }

        public async Task<int> UpdateAsync(UpdateItemDto item)
        {
            try
            {
                var exist = await _itemRepo.GetAsync(item.id);
                if (exist == null)
                    throw new Exception("Can't find this item to update.");

                if (string.IsNullOrWhiteSpace(item.Name))
                    throw new Exception("Item name cannot be empty.");

                if (item.StockQuantity < 0)
                    throw new Exception("Stock quantity cannot be negative.");

                exist.Name = item.Name.ToLower(); 
                exist.StockQuantity = item.StockQuantity;

                var result = await _itemRepo.UpdateAsync(exist);
                if (result == 0)
                    throw new Exception("Failed to update the item.");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the item: " + ex.Message);
            }
        }
        public async Task<int> IncreaseStockAsync(int itemId, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            var item = await _itemRepo.GetAsync(itemId);
            if (item == null)
                throw new Exception("Item not found.");

            item.StockQuantity += amount;

            return await _itemRepo.UpdateAsync(item);
        }
        public async Task<int> DecreaseStockAsync(int itemId, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            var item = await _itemRepo.GetAsync(itemId);
            if (item == null)
                throw new Exception("Item not found.");

            if (item.StockQuantity < amount)
                throw new InvalidOperationException("Not enough stock to decrease.");

            item.StockQuantity -= amount;

            return await _itemRepo.UpdateAsync(item);
        }



    }
}
