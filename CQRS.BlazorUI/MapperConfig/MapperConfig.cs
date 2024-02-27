using AutoMapper;
using CQRS.BlazorUI.Models.LeaveType;
using CQRS.BlazorUI.Services.Base;

namespace CQRS.BlazorUI.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveTypeDTO, LeaveTypeVM>().ReverseMap();
        }
    }
}
