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
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLeaveAllocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var deleteLeaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(request.Id);
            if (deleteLeaveType == null) throw new NotFoundException(nameof(LeaveType), request.Id);
            await _unitOfWork.LeaveTypeRepo.DeleteAsync(deleteLeaveType);
            return deleteLeaveType.Id;
        }
    }
}
