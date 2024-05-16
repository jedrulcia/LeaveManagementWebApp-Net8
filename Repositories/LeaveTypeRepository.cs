using LeaveManagementWebApp.Contracts;
using LeaveManagementWebApp.Data;

namespace LeaveManagementWebApp.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
