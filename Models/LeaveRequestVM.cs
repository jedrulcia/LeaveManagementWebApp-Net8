using LeaveManagementWebApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebApp.Models
{
	public class LeaveRequestVM : LeaveRequestCreateVM
	{
		public int Id { get; set; }
		[Display (Name = "Date requested")]
		public DateTime DateRequested { get; set; }
        [Display(Name = "Leave type")]
		public LeaveType LeaveType { get; set; }
        public bool? Approved { get; set; }
		public bool Cancelled { get; set; }
	}
}
