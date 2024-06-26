﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagementWebApp.Contracts;
using LeaveManagementWebApp.Controllers;
using LeaveManagementWebApp.Data;
using LeaveManagementWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementWebApp.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly IEmailSender emailSender;
		private readonly AutoMapper.IConfigurationProvider configurationProvider;
		private readonly UserManager<Employee> userManager;

		public LeaveRequestRepository(ApplicationDbContext context,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			ILeaveAllocationRepository leaveAllocationRepository,
			IEmailSender emailSender,
			AutoMapper.IConfigurationProvider cofigurationProvider,
			UserManager<Employee> userManager) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.emailSender = emailSender;
			this.configurationProvider = cofigurationProvider;
			this.userManager = userManager;
		}

		public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);

			var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeID);
			if (leaveAllocation == null)
			{
				return false;
			}

			int daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;
			if(daysRequested > leaveAllocation.NumberOfDays)
			{
				return false;
			}

			var leaveRequest = mapper.Map<LeaveRequest>(model);
			leaveRequest.DateRequested = DateTime.Now;
			leaveRequest.RequestingEmployeeId = user.Id;

			await AddAsync(leaveRequest);

			await emailSender.SendEmailAsync(user.Email, "Leave request submistted succesfully", $"Your leave request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval");

			return true;
		}

		public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
			var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
			var requests = await GetAllAsync(user.Id);

			var model = new EmployeeLeaveRequestViewVM(allocations, requests);

			return model;
		}

		public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
		{
			return await context.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId)
				.ProjectTo<LeaveRequestVM>(configurationProvider)
				.ToListAsync();
		}

		public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
		{
			var leaveRequests = await context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
			var model = new AdminLeaveRequestViewVM
			{
				TotalRequests = leaveRequests.Count,
				ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
				PendingRequests = leaveRequests.Count(q => q.Approved == null),
				RejectedRequests = leaveRequests.Count(q => q.Approved == false),
				LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
			};

			foreach (var leaveRequest in model.LeaveRequests)
			{
				leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
			}

			return model;
		}

		public async Task ChangeApprovalStatus(int leaveRequestId, bool approvalStatus)
		{
			var leaveRequest = await GetAsync(leaveRequestId);
			leaveRequest.Approved = approvalStatus;

			if (leaveRequest.Approved == true)
			{
				var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeID);
				int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
				allocation.NumberOfDays -= daysRequested;

				await leaveAllocationRepository.UpdateAsync(allocation);
			}

			await UpdateAsync(leaveRequest);

			var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

			await emailSender.SendEmailAsync(user.Email, "Leave request approval status", $"Your leave request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}.");
		}

		public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
		{
			var leaveRequest = await context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.ID == id);
			if (leaveRequest == null)
			{
				return null;
			}
			var model = mapper.Map<LeaveRequestVM>(leaveRequest);
			model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

			return model;
		}

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
			var leaveRequest = await GetAsync(leaveRequestId);
			leaveRequest.Cancelled = true;
			await UpdateAsync(leaveRequest);

			var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

			await emailSender.SendEmailAsync(user.Email, "Leave request cancelled", $"Your leave request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been cancelled.");
		}
    }
}
