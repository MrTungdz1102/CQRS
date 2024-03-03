using CQRS.Application.InterfaceContracts.Identity;
using CQRS.Application.Models.Identity;
using CQRS.Identity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Identity.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly IHttpContextAccessor _contextAccessor;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
          //  _contextAccessor = contextAccessor;
        }
        public async Task<Employee> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Employee
            {
                Email = employee.Email,
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Employee
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();
        }
    }
}
