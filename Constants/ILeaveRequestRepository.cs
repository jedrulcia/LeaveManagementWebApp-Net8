using LeaveManagementWebApp.Contracts;
using LeaveManagementWebApp.Data;
using LeaveManagementWebApp.Models;

namespace LeaveManagementWebApp.Constants
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
    }
}
