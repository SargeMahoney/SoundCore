using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments
{
    public class AppointmentData
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public string CategoryColor { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<Guid> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public Guid RoomId { get; set; }
    }
}
