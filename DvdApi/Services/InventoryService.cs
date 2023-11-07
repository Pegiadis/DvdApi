using System.Runtime.CompilerServices;
using DvdApi.DatabaseOperations;
using DvdApi.Models;

namespace DvdApi.Services
{
    public interface IInventoryService
    {
        Task<List<Inventory>> GetAllInventoryAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<Inventory> UpdateInventoryAsync(Inventory inventory);
        Task<bool> DeleteInventoryAsync(int id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly InventoryOperations _dbAccess;
        public InventoryService()
        {
            _dbAccess = new InventoryOperations();
        }

        public async Task<List<Inventory>> GetAllInventoryAsync()
        {
            return await _dbAccess.GetAllInventoryAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _dbAccess.GetInventoryByIdAsync(id);
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            return await _dbAccess.AddInventoryAsync(inventory);
        }

        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            return await _dbAccess.UpdateInventoryAsync(inventory);
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            return await _dbAccess.DeleteInventoryAsync(id);
        }

    }
}