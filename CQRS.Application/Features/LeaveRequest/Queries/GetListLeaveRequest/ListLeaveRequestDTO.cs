using CQRS.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveRequest.Queries.GetListLeaveRequest
{
    public class ListLeaveRequestDTO
    {
        public int Id { get; set; }
      //  public Employee Employee { get; set; }
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set; }
    }
}
