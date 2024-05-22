using LeaveManagementWebApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebApp.Models
{
    public class LeaveRequestCreateVM
    {
        [Required]
        [Display(Name ="Start date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; }
        [Required]
        public int LeaveTypeID { get; set; }
        public SelectList LeaveTypes { get; set; }
        public string RequestComments { get; set; }
    }
}
