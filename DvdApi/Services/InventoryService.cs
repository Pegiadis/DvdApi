using System.Runtime.CompilerServices;
using DvdApi.DatabaseOperations;
using DvdApi.Models;

namespace DvdApi.Services
{
    public class InventoryService
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

    }
}