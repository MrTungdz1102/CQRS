using AutoMapper;
using CQRS.Application.Features.LeaveType.Commands.CreateLeaveType;
using CQRS.Application.Features.LeaveType.Commands.UpdateLeaveType;
using CQRS.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CQRS.Application.Features.LeaveType.Queries.GetLeaveTypeDetail;
using CQRS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDTO>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeCommand>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeCommand>().ReverseMap();
        }
    }
}
