using AutoMapper;
using CQRS.Application.Exceptions;
using CQRS.Application.InterfaceContracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateLeaveTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            // convert dTO to object
            // add to db and return
            var validator = new CreateLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestException("Invalid LeaveType", validationResult);

            var leaveTypeCreate = _mapper.Map<Domain.Models.LeaveType>(request);
            await _unitOfWork.LeaveTypeRepo.AddAsync(leaveTypeCreate);
            return leaveTypeCreate.Id;
        }
    }
}
