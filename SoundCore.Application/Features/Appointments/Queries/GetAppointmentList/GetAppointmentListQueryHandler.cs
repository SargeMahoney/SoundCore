using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentListQueryHandler : IRequestHandler<GetAppointmentListQuery, List<AppointMentListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IRoomsRepository _roomRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentListQueryHandler(IMapper mapper, IRoomsRepository roomRepository, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._roomRepository = roomRepository;
            this._appointmentRepository = appointmentRepository;
        }
        public async Task<List<AppointMentListVm>> Handle(GetAppointmentListQuery request, CancellationToken cancellationToken)
        {
            var allRooms = (await this._roomRepository.ListAllAsync()).OrderBy(x => x.Name);
            var allAppointments = (await this._appointmentRepository.ListAllAsync()).OrderByDescending(x => x.CreationDate);
            foreach (var appointment in allAppointments)
            {
                appointment.Room = allRooms.FirstOrDefault(r => r.Id == appointment.RoomId);
            }
            return this._mapper.Map<List<AppointMentListVm>>(allAppointments);
        }
    }
}
