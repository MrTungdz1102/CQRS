using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Commands.ChangeStatusLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalCommandValidator()
        {
            RuleFor(x => x.Approved).NotNull().WithMessage("Approval status cannot be null");
        }
    }
}
