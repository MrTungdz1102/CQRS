using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Queries.GetLeaveTypeDetail
{
    public class LeaveTypeDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDay { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
