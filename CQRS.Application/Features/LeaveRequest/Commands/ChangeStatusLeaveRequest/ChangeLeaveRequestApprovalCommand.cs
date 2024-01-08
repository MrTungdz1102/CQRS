using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Commands.ChangeStatusLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public bool Approved { get; set; }
    }
}
