using MediatR;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand : IRequest<Appointment>
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string Owner { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
