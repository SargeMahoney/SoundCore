using SoundCore.Domain.Enum;
using System;
using System.Text.Json.Serialization;

namespace SoundCore.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoomState State { get; set; }
        public DateTime CreationDate { get; set; }

 
        public string SearchableField
        {
            get
            {
                return $"{Name.ToString()} {Description.ToString()} {State.ToString()}";
            }
        }
    }
}
