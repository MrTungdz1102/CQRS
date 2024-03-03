using Blazored.LocalStorage;
using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Services.Base;

namespace CQRS.BlazorUI.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
        }

        public Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
