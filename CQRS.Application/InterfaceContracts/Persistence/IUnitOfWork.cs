using CQRS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.InterfaceContracts.Persistence
{
    public interface IUnitOfWork
    {
        //IRepository<LeaveAllocation> LeaveAllocationRepo { get; }
        //IRepository<LeaveRequest> LeaveRequestRepo { get; }
        //IRepository<LeaveType> LeaveTypeRepo { get; }

        ILeaveTypeRepository LeaveTypeRepo { get; }
        ILeaveRequestRepository LeaveRequestRepo { get; }
        ILeaveAllocationRepository LeaveAllocationRepo { get; }
    }
}
