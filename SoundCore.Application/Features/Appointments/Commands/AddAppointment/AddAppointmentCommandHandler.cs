using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public AddAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }
        public async Task<Guid> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            
            var newAppointment = _mapper.Map<Appointment>(request);
            var addAppointmentResult = await _appointmentRepository.AddAsync(newAppointment);
            return addAppointmentResult.Id;

        }
    }
}
