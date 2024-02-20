using AutoMapper;
using CQRS.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using CQRS.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CQRS.Application.InterfaceContracts.Infrastructure;
using CQRS.Application.InterfaceContracts.Persistence;
using CQRS.Application.MappingProfiles;
using CQRS.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.UnitTest.Features.LeaveType.Queries
{
    public class GetLeaveTypeQueryHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetLeaveRequestDetailQueryHandler>> _logger;

        public GetLeaveTypeQueryHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<IAppLogger<GetLeaveRequestDetailQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetLeaveTypesQuery(), default);
            result.ShouldBeOfType<List<LeaveTypeDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
