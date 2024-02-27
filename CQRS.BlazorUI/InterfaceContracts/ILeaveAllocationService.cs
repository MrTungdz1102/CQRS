using CQRS.BlazorUI.Services.Base;

namespace CQRS.BlazorUI.InterfaceContracts
{
    public interface ILeaveAllocationService
    {
        Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
    }
}
