using CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using CQRS.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using CQRS.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllLeaveAllocation")]
        public async Task<ActionResult> GetAllLeaveAllocation()
        {
            return Ok(await _mediator.Send(new GetLeaveAllocationsQuery()));
        }

        [HttpGet("GetDetailLeaveAllocation/{id:int}")]
        public async Task<ActionResult> GetDetailLeaveAllocation(int id)
        {
            return Ok(await _mediator.Send(new GetLeaveAllocationDetailQuery { Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeaveAllocation(CreateLeaveAllocationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLeaveAllocation(UpdateLeaveAllocationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLeaveAllocation(int id)
        {
            return Ok(await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id}));
        }
    }
}
