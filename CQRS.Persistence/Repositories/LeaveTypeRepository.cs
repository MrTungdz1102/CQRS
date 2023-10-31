using Ardalis.Specification;
using CQRS.Application.InterfaceContracts.Persistence;
using CQRS.Domain.Models;
using CQRS.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Persistence.Repositories
{
    public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
        [Obsolete]
        // using ardalis package instead
        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(x => x.Name == name);
        }
    }
}
