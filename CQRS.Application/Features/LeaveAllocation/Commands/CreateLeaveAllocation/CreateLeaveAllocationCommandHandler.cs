using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.Features.LeaveType.Commands.CreateLeaveType;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateLeaveAllocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            // convert dTO to object
            // add to db and return
            var validator = new CreateLeaveAllocationCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestException("Invalid Leave Allocation Request", validationResult);
            var leaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(request.LeaveTypeId);
            var period = DateTime.Now.Year;
            //Assign Allocations IF an allocation doesn't already exist for period and leave type

            var leaveAllocationCreate = _mapper.Map<Domain.Models.LeaveAllocation>(request);
            await _unitOfWork.LeaveAllocationRepo.AddAsync(leaveAllocationCreate);
            return Unit.Value;
        }
    }
}
