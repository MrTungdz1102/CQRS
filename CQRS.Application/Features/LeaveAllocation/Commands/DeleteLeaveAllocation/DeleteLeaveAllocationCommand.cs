using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
