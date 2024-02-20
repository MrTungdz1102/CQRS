using CQRS.Domain.Models;
using CQRS.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.IntegrationTest
{
    public class DbContextTest
    {
        private DbContextOptions<ApplicationDbContext> option;
        private readonly ApplicationDbContext _db;

        public DbContextTest()
        {
            option = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "tempDatabase").Options;
            _db = new ApplicationDbContext(option);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDay = 10,
                Name = "Test Vacation"
            };

            await _db.LeaveTypes.AddAsync(leaveType);
            await _db.SaveChangesAsync();

            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDay = 10,
                Name = "Test Vacation"
            };
            await _db.LeaveTypes.AddAsync(leaveType);
        //    _db.LeaveTypes.Update(leaveType);
            await _db.SaveChangesAsync();

            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}
