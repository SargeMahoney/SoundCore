using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Domain.Entities;
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
            this._appointmentRepository = appointmentRepository;
            this._mapper = mapper;
        }
        public async Task<Appointment> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var modifiedAppointment = this._mapper.Map<Appointment>(request);
            var updateAppointmentResult = await this._appointmentRepository.UpdateAsync(modifiedAppointment);

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
