using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCoreAPI.Entities;

namespace WebCoreAPI.Repositories
{
    public interface IItemRepository
    {
        Task<Item> getItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid Id);
    }
}