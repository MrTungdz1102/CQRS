using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail
{
    public class GetLeaveAllocationDetailQueryHanlder : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetLeaveAllocationDetailQueryHanlder(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<LeaveAllocationDetailDTO> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepo.GetByIdAsync(request.Id);
            if (leaveAllocation == null) throw new NotFoundException("Not found LeaveAllocation", request.Id);
            return _mapper.Map<LeaveAllocationDetailDTO>(leaveAllocation);
        }
    }
}
