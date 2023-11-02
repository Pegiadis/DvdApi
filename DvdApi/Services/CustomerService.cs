using System.Runtime.CompilerServices;
using DvdApi.DatabaseOperations;
using DvdApi.Models;

namespace DvdApi.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id, Customer customer);
        Task DeleteCustomerAsync(int id);
    }


    public class CustomerService : ICustomerService
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

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _dbAccess.GetCustomerAsync(id);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _dbAccess.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            await _dbAccess.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _dbAccess.DeleteCustomerAsync(id);
        }

    }
}
