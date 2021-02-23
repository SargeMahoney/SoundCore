using MediatR;
using System.Collections.Generic;

namespace SoundCore.Application.Features.Rooms.Queries.GetRoomsList
{
    public class GetRoomListQuery : IRequest<List<RoomListVm>>
    {
    }
}
