using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Queries.GetLeaveTypeDetail
{
    public record GetLeaveTypeDetailQuery (int Id) : IRequest<LeaveTypeDetailDTO>;
}
