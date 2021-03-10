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

namespace SoundCore.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Appointment>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        public UpdateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<Appointment> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var modifiedAppointment = _mapper.Map<Appointment>(request);
            var updateAppointmentResult = await _appointmentRepository.UpdateAsync(modifiedAppointment);

            if (updateAppointmentResult.Success)
            {
                return modifiedAppointment;
            }
            else
            {
                return new Appointment();
            }
        }
    }
}
