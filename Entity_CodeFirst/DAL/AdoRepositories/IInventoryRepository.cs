using Entity_CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL.Interfaces
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetAllInventoriesAsync();
        Task<Inventory> GetInventoryAsync(int inventoryId);
        Task CreateInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(int inventoryId);
    }
}
