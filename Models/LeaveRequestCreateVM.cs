using LeaveManagementWebApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebApp.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Required]
        [Display(Name ="Start date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; }
        [Required]
        [Display(Name = "Leave type")]
        public int LeaveTypeID { get; set; }
        public SelectList? LeaveTypes { get; set; }
        [Display(Name = "Request comments")]
        public string? RequestComments { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
            if(StartDate > EndDate)
            {
                yield return new ValidationResult("The start date must be before end date", new[] { nameof(StartDate), nameof(EndDate) });
            }

            if(RequestComments?.Length > 250)
            {
                yield return new ValidationResult("Comments are too long", new[] { nameof(RequestComments), });
            }
		}
	}
}
