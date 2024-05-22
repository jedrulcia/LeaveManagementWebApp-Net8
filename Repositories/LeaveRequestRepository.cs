using LeaveManagementWebApp.Constants;
using LeaveManagementWebApp.Data;

namespace LeaveManagementWebApp.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
