using AutoMapper;
using CQRS.Application.InterfaceContracts.Infrastructure;
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
        private readonly IAppLogger<GetLeaveTypeDetailQueryHandler> _logger;
        public GetLeaveTypeDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetLeaveTypeDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<LeaveTypeDetailDTO> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Models.LeaveType? leaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(request.Id);
            var data =  _mapper.Map<LeaveTypeDetailDTO>(leaveType);
            _logger.LogInformation("Leave type was retrieved successfully");
            return data;
        }
    }
}
