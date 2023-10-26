using AutoMapper;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Queries.GetLeaveTypeDetail
{
    public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDetailDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetLeaveTypeDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<LeaveTypeDetailDTO> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(request.Id);
            return _mapper.Map<LeaveTypeDetailDTO>(leaveType);
        }
    }
}
