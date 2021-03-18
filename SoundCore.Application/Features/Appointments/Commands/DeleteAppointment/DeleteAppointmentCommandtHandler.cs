using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandtHandler : IRequestHandler<DeleteAppointmentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentCommandtHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }


        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentToDelete = await this._appointmentRepository.GetByIdAsync(request.AppointmentId);

            if (appointmentToDelete == null)
            {
                throw new Exception();
            }

            await this._appointmentRepository.DeleteAsync(appointmentToDelete);

            return Unit.Value;
        }
    }
}
