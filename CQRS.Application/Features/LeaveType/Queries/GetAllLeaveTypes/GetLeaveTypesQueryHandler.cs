using AutoMapper;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetLeaveTypesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            // convert data object to DTO
            // return DTO
            var leaveTypes = await _unitOfWork.LeaveTypeRepo.ListAsync();
            return _mapper.Map<List<LeaveTypeDTO>>(leaveTypes);           
        }
    }
}
