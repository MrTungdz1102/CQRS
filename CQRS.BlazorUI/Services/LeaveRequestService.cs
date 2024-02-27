using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Models.LeaveRequest;
using CQRS.BlazorUI.Services.Base;

namespace CQRS.BlazorUI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client) : base(client)
        {
        }

        public Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> CancelLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestVM> GetLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
