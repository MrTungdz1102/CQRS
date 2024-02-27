using CQRS.Application.InterfaceContracts.Persistence;
using CQRS.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.UnitTest.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<IUnitOfWork> GetMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDay = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDay = 15,
                    Name = "Test Sick"
                },
                new LeaveType
                {
                    Id = 3,
                    DefaultDay = 15,
                    Name = "Test Maternity"
                }
            };
            var mockRepo = new Mock<IUnitOfWork>();
         //   var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.LeaveTypeRepo.ListAsync(default)).ReturnsAsync(leaveTypes);
            // _mockOrderRepository.Setup(x => x.ListAsync(It.IsAny<ISpecification<Order>>(), default)).ReturnsAsync(new List<Order> { order });

            mockRepo.Setup(x => x.LeaveTypeRepo.AddAsync(It.IsAny<LeaveType>(), default)).Returns((LeaveType leaveType, CancellationToken cancellationToken) =>
            {
                leaveTypes.Add(leaveType);
                return Task.FromResult(leaveType);
            });
            return mockRepo;
        }
    }
}
