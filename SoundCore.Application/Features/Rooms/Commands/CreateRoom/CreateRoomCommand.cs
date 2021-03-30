using MediatR;
using SoundCore.Domain.Enum;

namespace SoundCore.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<CreateRoomCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public RoomState State { get; set; }

        public override string ToString()
        {
            return $"Created new Room {Name} ";
        }

    }
}
