using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Queries.GetRoomsList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, List<RoomListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IRoomsRepository _roomRepository;

        public GetRoomListQueryHandler(IMapper mapper, IRoomsRepository roomRepository)
        {
            this._mapper = mapper;
            this._roomRepository = roomRepository;
        }
        public async Task<List<RoomListVm>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await this._roomRepository.ListAllAsync()).OrderBy(x => x.Name);
            return this._mapper.Map<List<RoomListVm>>(allCategories);
        }
    }
}
