using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Queries.GetRoomsList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, List<RoomListVm>>
    {
        public Task<List<RoomListVm>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
