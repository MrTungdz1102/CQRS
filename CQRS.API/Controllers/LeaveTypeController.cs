using CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using CQRS.Application.Features.LeaveType.Commands.CreateLeaveType;
using CQRS.Application.Features.LeaveType.Commands.DeleteLeaveType;
using CQRS.Application.Features.LeaveType.Commands.UpdateLeaveType;
using CQRS.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CQRS.Application.Features.LeaveType.Queries.GetLeaveTypeDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveTypeDTO>>> Get()
        {
           return Ok(await _mediator.Send(new GetLeaveTypesQuery())); 

        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDetailDTO> Get(int id)
        {
            return await _mediator.Send(new GetLeaveTypeDetailQuery(id));
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<int> Post(CreateLeaveTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut]
        public async Task<ActionResult<Unit>> Put(UpdateLeaveTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _mediator.Send(new DeleteLeaveTypeCommand { Id = id});
        }
    }
}
