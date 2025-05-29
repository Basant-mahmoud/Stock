using Microsoft.EntityFrameworkCore;
using Stock.Stock.Application.Dto;
using Stock.Stock.Domain.InterfacesRepo;
using Stock.Stock.Domain.Models;
using Stock.Stock.Infrastructure.Persistence;

namespace Stock.Stock.Infrastructure.Repo
{
    public class ItemRepository : IItemRepository
    {
        private readonly StockDBContext _context;
        public ItemRepository(StockDBContext context)
        {
            _context = context;
        }

        public async Task<Item> addAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
            
        }

        public async Task<int> deleteAsync(Item item)
        {
             _context.Items.Remove(item);
            return await _context.SaveChangesAsync();

        }


          public async Task<List<Item>> GetAllAsync()
          {
            return await _context.Items.ToListAsync();
          }


        public async Task<Item> GetAsync(int id)
        {
           return  await _context.Items.FindAsync(id);
        }

        public async Task<int> UpdateAsync(Item item)
        {
             _context.Items.Update(item);
            return await _context.SaveChangesAsync();
        }
        public async Task<Item> GetByNameAsync(string name)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.Name.ToLower() == name.ToLower());
            return item;
           
        }
    }
}
