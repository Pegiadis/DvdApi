using DvdApi.Models;
using DvdApi.DatabaseOperations;

namespace DvdApi.Services
{
    public class StaffService
    {
        private readonly StaffOperations _dbAccess;

        public StaffService()
        {
            _dbAccess = new StaffOperations();
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _dbAccess.GetAllStaffAsync();
        }

    }
}
