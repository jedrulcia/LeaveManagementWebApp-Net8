using AutoMapper;
using LeaveManagementWebApp.Constants;
using LeaveManagementWebApp.Contracts;
using LeaveManagementWebApp.Data;
using LeaveManagementWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementWebApp.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ILeaveAllocationRepository leaveAllocationRepository;
		private readonly UserManager<Employee> userManager;

		public LeaveRequestRepository(ApplicationDbContext context, 
			IMapper mapper, 
			IHttpContextAccessor httpContextAccessor, 
			ILeaveAllocationRepository leaveAllocationRepository,
			UserManager<Employee> userManager) : base(context)
        {
			this.context = context;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.leaveAllocationRepository = leaveAllocationRepository;
			this.userManager = userManager;
		}

		public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);

			var leaveRequest = mapper.Map<LeaveRequest>(model);
			leaveRequest.DateRequested = DateTime.Now;
			leaveRequest.RequestingEmployeeId = user.Id;
			await AddAsync(leaveRequest);
		}

		public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
			var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
			var requests = mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));

			var model = new EmployeeLeaveRequestViewVM(allocations, requests);

			return model;
		}

		public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
		{
			return await context.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId).ToListAsync();
		}
	}
}
