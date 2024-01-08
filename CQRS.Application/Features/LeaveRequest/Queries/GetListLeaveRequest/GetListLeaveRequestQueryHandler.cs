using AutoMapper;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Queries.GetListLeaveRequest
{
    public class GetListLeaveRequestQueryHandler : IRequestHandler<GetListLeaveRequestQuery, List<ListLeaveRequestDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListLeaveRequestQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ListLeaveRequestDTO>> Handle(GetListLeaveRequestQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
