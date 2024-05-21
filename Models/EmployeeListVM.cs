﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebApp.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
		[Display(Name = "Email address")]
		public string Email { get; set; }
		[Display(Name = "Date joined")]
        public string DateJoined { get; set; }
    }
}