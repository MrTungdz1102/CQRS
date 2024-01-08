using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.Features.LeaveType.Queries.GetLeaveTypeDetail;
using CQRS.Application.InterfaceContracts.Infrastructure;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
        public UpdateLeaveTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.LeaveType? leaveType = await _unitOfWork.LeaveTypeRepo.GetByIdAsync(request.Id);
            if (leaveType == null) throw new NotFoundException("Not Found LeaveType", request.Id);
            var validator = new UpdateLeaveTypeCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
                throw new BadRequestException("Invalid Leave type", validationResult);
            }
            //   var updateLeaveType = _mapper.Map<Domain.Models.LeaveType>(request);
            // must dto first
            _mapper.Map(request, leaveType);
            await _unitOfWork.LeaveTypeRepo.UpdateAsync(leaveType);
            return Unit.Value;
        }
    }
}
