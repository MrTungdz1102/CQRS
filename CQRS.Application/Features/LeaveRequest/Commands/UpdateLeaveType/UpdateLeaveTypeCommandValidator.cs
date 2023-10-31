using CQRS.Application.InterfaceContracts.Persistence;
using FluentValidation;

namespace CQRS.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLeaveTypeCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {
                var existedLeaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(id);
                return existedLeaveType is null ? false : true;
            }).WithMessage("ID Must be unique");

            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");
        }
    }
}
