using CQRS.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
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
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand request)
        {
            int response =  await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<Unit> Put(int id, [FromBody] string value)
        {
            return await _mediator.Send(new UpdateLeaveAllocationCommand());
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
