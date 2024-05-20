using LeaveManagementWebApp.Data;

namespace LeaveManagementWebApp.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int LeaveTypeId, int period);
    }
}
