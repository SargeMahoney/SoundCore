using SoundCore.Application.Models.Results;

namespace SoundCore.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandResponse : BaseResult
    {
        public CreateRoomCommandResponse() : base()
        {

        }

        public CreateRoomDto Room { get; set; }
    }
}
