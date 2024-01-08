using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDetailDTO> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Models.LeaveRequest? leaveRequest = await _unitOfWork.LeaveRequestRepo.GetByIdAsync(request.Id);
            if (leaveRequest is null) throw new NotFoundException("Not Found Leave Request With Id", request.Id);
            LeaveRequestDetailDTO data = _mapper.Map<LeaveRequestDetailDTO>(leaveRequest);
            //  data.Employee = null;
            return data;
        }
    }
}
