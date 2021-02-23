using MediatR;

namespace SoundCore.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<CreateRoomCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Created new Room {Name} ";
        }

    }
}
