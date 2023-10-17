using System.Runtime.CompilerServices;
using DvdApi.DatabaseOperations;
using DvdApi.Models;

namespace DvdApi.Services
{
    public class CustomerService
    {
        private readonly CustomerOperations _dbAccess;
        public CustomerService()
        {
            _dbAccess = new CustomerOperations();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbAccess.GetAllCustomersAsync();
        }

    }
}
