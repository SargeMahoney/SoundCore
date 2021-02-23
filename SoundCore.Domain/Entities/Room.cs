using SoundCore.Domain.Enum;
using System;

namespace SoundCore.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoomState State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
