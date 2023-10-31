using CQRS.Application.InterfaceContracts.Persistence;
using CQRS.Domain.Models;
using CQRS.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ILeaveAllocationRepository LeaveAllocationRepo { get; private set; }
        public ILeaveRequestRepository LeaveRequestRepo { get; private set; }
        public ILeaveTypeRepository LeaveTypeRepo { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            LeaveAllocationRepo = new LeaveAllocationRepository(_db);
            LeaveRequestRepo = new LeaveRequestRepository(_db);
            LeaveTypeRepo = new LeaveTypeRepository(_db);
        }
    }
}
