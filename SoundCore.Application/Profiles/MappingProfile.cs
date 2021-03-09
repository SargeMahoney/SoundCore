using AutoMapper;
using SoundCore.Application.Features.Appointments.Commands.AddAppointment;
using SoundCore.Application.Features.Appointments.Queries.GetAppointmentList;
using SoundCore.Application.Features.Rooms.Commands.CreateRoom;
using SoundCore.Application.Features.Rooms.Queries.GetRoomsList;
using SoundCore.Domain.Entities;

namespace SoundCore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Room, RoomListVm>().ReverseMap();

            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomCommand, Room>().ReverseMap();

            CreateMap<Appointment, AppointMentListVm>().ReverseMap();
            CreateMap<Appointment, AddAppointmentCommand>().ReverseMap();
        }
    }
}
