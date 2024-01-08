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
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLeaveAllocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepo.GetByIdAsync(request.Id);
            if (leaveAllocation == null) throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            await _unitOfWork.LeaveAllocationRepo.DeleteAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}
