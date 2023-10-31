using CQRS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.InterfaceContracts.Persistence
{
    public interface ILeaveTypeRepository : IRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
