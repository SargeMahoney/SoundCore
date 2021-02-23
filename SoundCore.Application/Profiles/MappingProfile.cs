using AutoMapper;
using SoundCore.Application.Features.Rooms.Queries.GetRoomsList;
using SoundCore.Domain.Entities;

namespace SoundCore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Room, RoomListVm>().ReverseMap();
        }
    }
}
