﻿using CQRS.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public class LeaveAllocationDTO
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
