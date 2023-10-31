using Ardalis.Specification.EntityFrameworkCore;
using CQRS.Application.InterfaceContracts.Persistence;
using CQRS.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Persistence.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context; 
        public Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
