using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebApp.Models
{
	public class EmployeeAllocationVM : EmployeeListVM
	{
		public List<LeaveAllocationVM> LeaveAllocations { get; set; }
	}
}
