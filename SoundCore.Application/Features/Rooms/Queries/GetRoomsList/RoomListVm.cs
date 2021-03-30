using SoundCore.Domain.Enum;
using System;

namespace SoundCore.Application.Features.Rooms.Queries.GetRoomsList
{
    public class RoomListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        public RoomState State { get; set; }
    }
}
