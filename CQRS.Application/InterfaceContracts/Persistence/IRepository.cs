using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.InterfaceContracts.Persistence
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
