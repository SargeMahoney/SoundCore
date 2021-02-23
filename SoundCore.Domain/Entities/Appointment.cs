using System;

namespace SoundCore.Domain.Entities
{
    public class Appointment
    {

        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public string Owner { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
