using AutoMapper;
using CQRS.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using CQRS.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using CQRS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDetailDTO, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocationDTO, LeaveAllocation>().ReverseMap();
        }
    }
}
