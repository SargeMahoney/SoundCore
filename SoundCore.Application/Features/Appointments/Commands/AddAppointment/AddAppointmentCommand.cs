using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }  
        public string Owner { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


  
    }
}
