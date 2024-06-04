using AutoMapper;
using LeaveManagementWebApp.Data;
using LeaveManagementWebApp.Models;

namespace LeaveManagementWebApp.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<Employee, EmployeeListVM>().ReverseMap();
			CreateMap<Employee, EmployeeAllocationVM>().ReverseMap();
			CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>().ReverseMap();
            CreateMap<LeaveRequestCreateVM, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveType, LeaveRequestVM>().ReverseMap();
        }
    }
}
