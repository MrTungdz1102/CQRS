using CQRS.Application.InterfaceContracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        public readonly ILeaveRequestRepository _leaveRequest;
        public CreateLeaveRequestCommandValidator(ILeaveRequestRepository leaveRequest)
        {
            _leaveRequest = leaveRequest;
        }
    }
}
