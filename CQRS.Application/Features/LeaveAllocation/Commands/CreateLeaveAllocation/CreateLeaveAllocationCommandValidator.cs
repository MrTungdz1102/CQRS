using CQRS.Application.InterfaceContracts.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeaveAllocationCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(p => p.LeaveTypeId)
               .GreaterThan(0)
               .MustAsync(LeaveTypeMustExist)
               .WithMessage("{PropertyName} does not exist.");
        }
        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(id);
            return leaveType != null;
        }
    }  
}
