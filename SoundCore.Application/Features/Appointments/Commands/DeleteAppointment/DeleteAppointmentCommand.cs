using MediatR;
using System;

namespace SoundCore.Application.Features.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest
    {
        public Guid AppointmentId { get; set; }
    }
}
