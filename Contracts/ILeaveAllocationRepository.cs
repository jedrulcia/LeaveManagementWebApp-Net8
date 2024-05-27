using LeaveManagementWebApp.Data;
using LeaveManagementWebApp.Models;

namespace LeaveManagementWebApp.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int LeaveTypeId, int period);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
		Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId);
		Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
