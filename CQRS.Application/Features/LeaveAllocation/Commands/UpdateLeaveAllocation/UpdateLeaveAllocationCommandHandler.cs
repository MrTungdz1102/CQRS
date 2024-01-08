using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLeaveAllocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationCommandValidator(_unitOfWork);
            var validateResult = await validator.ValidateAsync(request);
            if (validateResult.Errors.Any()) throw new BadRequestException("Invalid Leave Allocation", validateResult);
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepo.GetByIdAsync(request.Id);
            if (leaveAllocation is null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            _mapper.Map(request, leaveAllocation);
            await _unitOfWork.LeaveAllocationRepo.UpdateAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}
