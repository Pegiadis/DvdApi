using DvdApi.Models;
using DvdApi.DatabaseOperations;

namespace DvdApi.Services
{

    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task<Staff> AddStaffAsync(Staff staff);
        Task<Staff> UpdateStaffAsync(int id, Staff staff);
        Task<bool> DeleteStaffAsync(int id);
    }

    public class StaffService : IStaffService   

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

    public async Task<Staff> GetStaffByIdAsync(int id)
    {
        return await _dbAccess.GetStaffByIdAsync(id);
    }

    public async Task<Staff> AddStaffAsync(Staff staff)
    {
        return await _dbAccess.AddStaffAsync(staff);
    }

    public async Task<Staff> UpdateStaffAsync(int id, Staff staff)
    {
        return await _dbAccess.UpdateStaffAsync(id, staff);
    }

    public async Task<bool> DeleteStaffAsync(int id)
    {
        return await _dbAccess.DeleteStaffAsync(id);
    }

    }
}
