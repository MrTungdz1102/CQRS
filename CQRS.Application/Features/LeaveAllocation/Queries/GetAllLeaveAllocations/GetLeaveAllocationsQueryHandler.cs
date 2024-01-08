using AutoMapper;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetLeaveAllocationsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.LeaveAllocationRepo.ListAsync();
            return _mapper.Map<List<LeaveAllocationDTO>>(data);
        }
    }
}
