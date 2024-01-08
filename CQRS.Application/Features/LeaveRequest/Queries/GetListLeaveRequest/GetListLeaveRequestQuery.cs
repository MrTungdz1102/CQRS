using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Queries.GetListLeaveRequest
{
    public class GetListLeaveRequestQuery : IRequest<List<ListLeaveRequestDTO>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
