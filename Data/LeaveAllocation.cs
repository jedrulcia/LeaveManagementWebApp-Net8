using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebApp.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeID")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeID { get; set; }

        public string EmployeeId { get; set; }

        public int Period { get; set; }

    }
}
