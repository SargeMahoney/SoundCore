using System;

namespace SoundCore.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }
}
